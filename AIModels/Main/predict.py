#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Main Disease Diagnosis Model - Scikit-Learn Inference Script (Optimized)
======================================================================
This script handles the inference for the new RandomForest model.
It supports the persistent READY signal and stdin/stdout JSON interface.
"""

import sys
import os
import json
import joblib
import warnings
import numpy as np
from datetime import datetime

# Hide warnings and TF noise (if any lingers)
warnings.filterwarnings('ignore')
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '3'

# Logging for debug
LOG_FILE = os.path.join(os.path.dirname(os.path.abspath(__file__)), "python_debug.log")
def log_debug(msg):
    with open(LOG_FILE, "a", encoding="utf-8") as f:
        f.write(f"[{datetime.now()}] {msg}\n")

class DiseasePredictor:
    def __init__(self, model_path, map_path, features_path, translation_path, symptom_map_path):
        # 1. Load Model
        self.model = joblib.load(model_path)
        
        # 2. Load Evidence Map
        self.evidence_name_map = joblib.load(map_path)
        
        # 3. Load Feature Order
        self.features = list(joblib.load(features_path)) # List of E_codes
        
        # Ensure AGE and SEX are in the features if not present in pkl
        if "AGE" not in self.features: self.features.append("AGE")
        if "SEX" not in self.features: self.features.append("SEX")
        
        # 4. Load Symptom to E-code map
        self.symptom_to_ecode = {}
        if os.path.exists(symptom_map_path):
            with open(symptom_map_path, 'r', encoding='utf-8') as f:
                self.symptom_to_ecode = json.load(f)
        
        # 5. Load Translations
        self.translations = {}
        if os.path.exists(translation_path):
            with open(translation_path, 'r', encoding='utf-8') as f:
                self.translations = json.load(f)

    def predict(self, input_data):
        # Create input vector (517 features)
        input_vector = np.zeros((1, len(self.features)))
        
        # Handle both list of symptoms or dict with additional info
        if isinstance(input_data, dict):
            # Check for symptoms names or direct evidence codes
            raw_symptoms = input_data.get("symptoms", [])
            evidence_codes = input_data.get("evidence_codes", [])
            age = input_data.get("age", 30)
            
            # Sex mapping (M -> 0, F -> 1)
            sex_val = input_data.get("sex", 0)
            if isinstance(sex_val, str):
                sex = 1 if sex_val.upper() == "F" else 0
            else:
                sex = sex_val
        else:
            raw_symptoms = input_data
            evidence_codes = []
            age = 30
            sex = 0

        # Set AGE and SEX
        if "AGE" in self.features:
            input_vector[0, self.features.index("AGE")] = age
        if "SEX" in self.features:
            input_vector[0, self.features.index("SEX")] = sex

        matched_ecodes = []
        clinical_indicators = set() # Track ALL symptoms for reasoning, even if model is blind to them
        
        # 1. Process direct evidence codes (E_codes)
        for e in evidence_codes:
            clinical_indicators.add(e)
            if e in self.features:
                matched_ecodes.append(e)

        # 2. Process symptom names (Search/Map)
        for s in raw_symptoms:
            if not s: continue
            s_norm = str(s).strip()
            
            # Check if this single symptom string is actually a JSON object (fallback)
            if s_norm.startswith("{"):
                try:
                    js = json.loads(s_norm)
                    if isinstance(js, list):
                        raw_symptoms.extend(js)
                        continue
                    if isinstance(js, dict):
                        if "evidence_codes" in js: evidence_codes.extend(js["evidence_codes"])
                        if "symptoms" in js: raw_symptoms.extend(js["symptoms"])
                        continue
                except: pass

            # Exact match from schema
            if s_norm in self.symptom_to_ecode:
                ecode = self.symptom_to_ecode[s_norm]
                clinical_indicators.add(ecode)
                if ecode in self.features: matched_ecodes.append(ecode)
            elif s_norm.startswith("E_"):
                clinical_indicators.add(s_norm)
                if s_norm in self.features: matched_ecodes.append(s_norm)
            else:
                # Fallback: Fuzzy search in questions/meanings
                for q, e in self.symptom_to_ecode.items():
                    if s_norm.lower() in q.lower() or q.lower() in s_norm.lower():
                        clinical_indicators.add(e)
                        if e in self.features: matched_ecodes.append(e)
                        break
        
        # Remove duplicates
        matched_ecodes = list(set(matched_ecodes))
        
        if not matched_ecodes and not clinical_indicators:
            return {"error": "No recognizable symptoms found", "disease": "Unknown", "confidence": 0}

        # Populate input vector (Multi-hot)
        for ecode in matched_ecodes:
            if ecode in self.features:
                idx = self.features.index(ecode)
                input_vector[0, idx] = 1

        try:
            # Predict probabilities
            probs = self.model.predict_proba(input_vector)[0]
            classes = self.model.classes_


            # --- Clinical Logic Post-Processing (Clinical Override System) ---
            
            # Phase 1: Identify Clinical Indicators & Flags
            red_flag_triggered = None # Store the primary emergency flag if any
            
            # Pre-calculation for faster loop
            has_chest_pain = any(x in clinical_indicators for x in ["E_55_@_V_101", "E_57_@_V_101", "E_133_@_V_101"])
            has_vomiting = any(x in clinical_indicators for x in ["E_211", "E_148"])
            has_rlq = any(x in clinical_indicators for x in ["E_55_@_V_87", "E_152_@_V_87"])
            has_ruq = any(x in clinical_indicators for x in ["E_55_@_V_85", "E_152_@_V_85"])
            has_neck = "E_94" in clinical_indicators # Stiff neck
            has_fever = "E_91" in clinical_indicators
            has_cough = "E_201" in clinical_indicators
            has_dyspnea = "E_66" in clinical_indicators
            has_neuro = any(x in clinical_indicators for x in ["E_84", "E_176", "E_157", "E_115", "E_93", "E_43", "E_156"])

            # Rule 1: Heart Attack (MI) Override
            if has_chest_pain and (age > 45 or "E_50" in clinical_indicators or "E_57_@_V_177" in str(clinical_indicators)):
                red_flag_triggered = "Myocardial infarction"

            # Rule 2: Appendicitis Override
            elif has_rlq and (has_fever or has_vomiting or "E_51" in clinical_indicators):
                red_flag_triggered = "Appendicitis"

            # Rule 3: Meningitis Override
            elif has_neck and (has_fever or "E_55_@_V_89" in clinical_indicators):
                red_flag_triggered = "Meningitis"
            
            # Rule 4: Cholecystitis Override
            elif has_ruq and has_fever:
                red_flag_triggered = "Cholecystitis"

            # Rule 5: Boerhaave Safeguard
            # If Boerhaave appears, it MUST HAVE vomiting + acute chest pain. Else it's GONE.
            cannot_be_boerhaave = not (has_chest_pain and has_vomiting) or \
                                  any(x in clinical_indicators for x in ["E_55_@_V_87", "E_55_@_V_89", "E_94"])

            # Phase 2: Apply Hard Probabilistic Filters
            for idx, name in enumerate(classes):
                name_str = str(name)
                
                # A. Force Red Flag if triggered
                if red_flag_triggered and red_flag_triggered in name_str:
                    probs[idx] = 1.0 # Force to winning
                    # No need to loop more? No, we need to zero others
                    continue
                
                # B. Absolute Zero for Unsupported Boerhaave
                if "Boerhaave" in name_str and cannot_be_boerhaave:
                    probs[idx] = 0.0
                    continue

                # C. Absolute Zero for Unsupported Rare/Neuro
                if any(x in name_str for x in ["Guillain", "Dyston", "Myasthenia", "Ebola"]):
                    if not has_neuro:
                        probs[idx] = 0.0
                        continue

                # D. Pediatric Penalties
                if name_str == 'Croup' and age > 10:
                    probs[idx] = 0.0
                elif name_str == 'Bronchiolitis' and age > 5:
                    probs[idx] *= 0.0001
                
                # E. Inguinal Hernia (Restrict to avoid hijacking RLQ)
                if name_str == 'Inguinal hernia' and has_rlq and not red_flag_triggered == "Appendicitis":
                    # If we have RLQ but it's not classic enough for Appendicitis red flag,
                    # we still keep Hernia as a POSSIBLITY but don't let it be 99%
                    probs[idx] = min(probs[idx], 0.3) 

                # F. Regular boosters for non-red-flag cases
                if "Pneumonia" in name_str and has_cough and has_fever:
                    probs[idx] = max(probs[idx] * 500, 0.4)
                
                if "Anemia" in name_str and "E_154" in clinical_indicators:
                    probs[idx] = max(probs[idx] * 200, 0.5)

            # Phase 3: Final Force (If Red Flag was found, zero out EVERYTHING else)
            if red_flag_triggered:
                for idx, name in enumerate(classes):
                    if red_flag_triggered not in str(name):
                        probs[idx] = 0.0
            
            # Re-normalize
            total_sum = np.sum(probs)
            if total_sum > 0:
                probs = probs / total_sum
            # -------------------------------------

            # Re-normalize probabilities
            total_sum = np.sum(probs)
            if total_sum > 0:
                probs = probs / total_sum
            # -------------------------------------
            
            # Get top 3 indices
            top_indices = np.argsort(probs)[-3:][::-1]
            
            top_results = []
            for idx in top_indices:
                conf = float(probs[idx]) * 100
                name_id = classes[idx]
                
                # Get translation info from diseases_ar.json
                trans = self.translations.get(name_id, {})
                
                top_results.append({
                    "disease": name_id,
                    "name_ar": trans.get("name_ar", name_id),
                    "description_ar": trans.get("description_ar", ""),
                    "precautions_ar": trans.get("precautions_ar", []),
                    "confidence": round(conf, 2)
                })

            return {
                "disease": top_results[0]["disease"],
                "name_ar": top_results[0]["name_ar"],
                "confidence": top_results[0]["confidence"],
                "top_results": top_results,
                "matched_count": len(matched_ecodes)
            }
        except Exception as e:
            log_debug(f"INFERENCE ERROR: {str(e)}")
            return {"error": str(e), "disease": "Error", "confidence": 0}

def main():
    # Setup UTF-8 for IO
    import sys
    import io
    sys.stdout = io.TextIOWrapper(sys.stdout.buffer, encoding='utf-8')
    sys.stdin = io.TextIOWrapper(sys.stdin.buffer, encoding='utf-8-sig')

    script_dir = os.path.dirname(os.path.abspath(__file__))
    paths = {
        "model": os.path.join(script_dir, 'medical_model.pkl'),
        "map": os.path.join(script_dir, 'evidences_map.pkl'),
        "features": os.path.join(script_dir, 'symptoms_features.pkl'),
        "trans": os.path.join(script_dir, 'diseases_ar.json'),
        "symmap": os.path.join(script_dir, 'symptom_to_ecode.json')
    }

    try:
        predictor = DiseasePredictor(paths["model"], paths["map"], paths["features"], paths["trans"], paths["symmap"])
        
        # CLI Argument Mode
        if len(sys.argv) > 1:
            try:
                symptoms = json.loads(sys.argv[1])
                print(json.dumps(predictor.predict(symptoms), ensure_ascii=False))
            except:
                print(json.dumps({"error": "Invalid JSON input"}))
            return

        # Interactive Mode (Persistent Process)
        print("READY")
        sys.stdout.flush()

        while True:
            line = sys.stdin.readline()
            if not line: break
            line = line.strip()
            if not line: continue
            if line.upper() == "EXIT": break

            try:
                symptoms = json.loads(line)
                result = predictor.predict(symptoms)
                print(json.dumps(result, ensure_ascii=False))
                sys.stdout.flush()
            except Exception as e:
                print(json.dumps({"error": f"JSON or Inference error: {str(e)}"}))
                sys.stdout.flush()

    except Exception as e:
        log_debug(f"STARTUP ERROR: {str(e)}")
        print(json.dumps({"error": f"Startup Error: {str(e)}"}))

if __name__ == "__main__":
    main()
