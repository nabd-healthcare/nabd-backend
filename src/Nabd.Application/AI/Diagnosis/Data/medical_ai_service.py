#!/usr/bin/env python3
# -*- coding: utf-8 -*-

import sys
import os
import json
import joblib
import warnings
import numpy as np

warnings.filterwarnings('ignore')
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '3'

class DiseasePredictor:
    def __init__(self, model_path, features_path, translation_path, symptom_map_path):
        self.model = joblib.load(model_path)
        self.features = list(joblib.load(features_path))
        if "AGE" not in self.features: self.features.append("AGE")
        if "SEX" not in self.features: self.features.append("SEX")
        
        self.symptom_to_ecode = {}
        if os.path.exists(symptom_map_path):
            with open(symptom_map_path, 'r', encoding='utf-8') as f:
                self.symptom_to_ecode = json.load(f)
                
        # Load reverse mapping for display
        self.ecode_to_name = {}
        rev_path = os.path.join(os.path.dirname(symptom_map_path), "ecode_to_name.json")
        if os.path.exists(rev_path):
            with open(rev_path, 'r', encoding='utf-8') as f:
                self.ecode_to_name = json.load(f)

        self.translations = {}
        if os.path.exists(translation_path):
            with open(translation_path, 'r', encoding='utf-8') as f:
                self.translations = json.load(f)

    def predict(self, input_data):
        input_vector = np.zeros((1, len(self.features)))
        
        if isinstance(input_data, dict):
            raw_symptoms = input_data.get("symptoms", [])
            evidence_codes = input_data.get("evidence_codes", [])
            age = input_data.get("age", 30)
            sex_val = input_data.get("sex", 0)
            sex = 1 if (isinstance(sex_val, str) and sex_val.upper() == "F") else (sex_val if isinstance(sex_val, int) else 0)
        else:
            raw_symptoms = input_data
            evidence_codes = []
            age = 30
            sex = 0

        if "AGE" in self.features: input_vector[0, self.features.index("AGE")] = age
        if "SEX" in self.features: input_vector[0, self.features.index("SEX")] = sex

        matched_ecodes = []
        clinical_indicators = set()
        
        for e in evidence_codes:
            clinical_indicators.add(e)
            if e in self.features: matched_ecodes.append(e)

        for s in raw_symptoms:
            if not s: continue
            s_norm = str(s).strip()
            if s_norm in self.symptom_to_ecode:
                ecode = self.symptom_to_ecode[s_norm]
                clinical_indicators.add(ecode)
                if ecode in self.features: matched_ecodes.append(ecode)
            elif s_norm.startswith("E_"):
                clinical_indicators.add(s_norm)
                if s_norm in self.features: matched_ecodes.append(s_norm)
        
        matched_ecodes = list(set(matched_ecodes))
        
        for ecode in matched_ecodes:
            if ecode in self.features:
                input_vector[0, self.features.index(ecode)] = 1

        try:
            probs = self.model.predict_proba(input_vector)[0]
            classes = self.model.classes_

            # Get Top 3 Results DIRECTLY from the model without any clinical logic
            top_indices = np.argsort(probs)[-3:][::-1]
            top_results = []
            for idx in top_indices:
                conf = float(probs[idx]) * 100
                name_id = classes[idx]
                trans = self.translations.get(name_id, {})
                top_results.append({
                    "disease": name_id,
                    "name_ar": trans.get("name_ar", name_id),
                    "description_ar": trans.get("description_ar", ""),
                    "precautions_ar": trans.get("precautions_ar", []),
                    "confidence": round(conf, 2)
                })

            # Get display names for symptoms
            display_symptoms = []
            for ecode in clinical_indicators:
                name = self.ecode_to_name.get(ecode, ecode)
                display_symptoms.append(name)

            return {
                "disease": top_results[0]["disease"],
                "name_ar": top_results[0]["name_ar"],
                "confidence": top_results[0]["confidence"],
                "top_results": top_results,
                "matched_count": len(matched_ecodes),
                "normalizedSymptoms": sorted(display_symptoms)
            }
        except Exception as e:
            return {"error": str(e), "disease": "Error", "confidence": 0}

def main():
    sys.stdout = open(sys.stdout.fileno(), mode='w', encoding='utf8', buffering=1)
    sys.stdin = open(sys.stdin.fileno(), mode='r', encoding='utf-8')

    script_dir = os.path.dirname(os.path.abspath(__file__))
    paths = {
        "model": os.path.join(script_dir, 'medical_model.pkl'),
        "features": os.path.join(script_dir, 'symptoms_features.pkl'),
        "trans": os.path.join(script_dir, 'diseases_ar.json'),
        "symmap": os.path.join(script_dir, 'symptom_to_ecode.json')
    }

    try:
        predictor = DiseasePredictor(paths["model"], paths["features"], paths["trans"], paths["symmap"])
        print("READY", flush=True)

        while True:
            line = sys.stdin.readline()
            if not line: break
            line = line.strip()
            if not line: continue
            if line.upper() == "EXIT": break

            try:
                symptoms = json.loads(line)
                result = predictor.predict(symptoms)
                print(json.dumps(result, ensure_ascii=False), flush=True)
            except Exception as e:
                print(json.dumps({"error": f"JSON or Inference error: {str(e)}"}, ensure_ascii=False), flush=True)
                
    except Exception as e:
        print(json.dumps({"error": f"Startup Error: {str(e)}"}), flush=True)

if __name__ == "__main__":
    main()
