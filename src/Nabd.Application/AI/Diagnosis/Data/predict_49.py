#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
New 49-Disease Diagnosis Model - Logic-based Inference
======================================================
Supports 3 input formats for symptoms:
  1. E-codes:        "E_91", "E_55_@_V_89"
  2. Short keywords: "fever", "cough", "chest pain", "anxiety"
  3. Full question:  "Do you have a fever (either felt or measured)?"
"""

import sys
import os
import json
import re
import warnings
from datetime import datetime

warnings.filterwarnings('ignore')

LOG_FILE = os.path.join(os.path.dirname(os.path.abspath(__file__)), "diagnosis_debug.log")

def log_debug(msg):
    try:
        with open(LOG_FILE, "a", encoding="utf-8") as f:
            f.write(f"[{datetime.now()}] {msg}\n")
    except:
        pass


# ─────────────────────────────────────────────
#  Keyword → E-code resolver
# ─────────────────────────────────────────────
STOP_WORDS = {
    'do', 'you', 'have', 'a', 'an', 'the', 'is', 'are', 'or', 'and', 'of',
    'in', 'to', 'that', 'your', 'been', 'has', 'did', 'were', 'it', 'at',
    'for', 'any', 'with', 'more', 'very', 'if', 'from', 'on', 'by', 'be',
    'as', 'into', 'than', 'this', 'these', 'when', 'there', 'about', 'can',
    'currently', 'recently', 'since', 'now', 'ever', 'some', 'no', 'not',
    'where', 'which', 'who', 'both', 'also', 'one', 'two', 'each', 'all',
    'its', 'their', 'over', 'just', 'been', 'being', 'was', 'will', 'would',
    'could', 'should', 'may', 'might', 'shall', 'had', 'has', 'having'
}

def build_keyword_index(symptom_to_ecode: dict) -> dict:
    """
    Build a word → {ecode: frequency} index from the symptom-question map.
    Allows fuzzy matching of short keywords to E-codes.
    """
    index = {}
    for question, ecode in symptom_to_ecode.items():
        clean = re.sub(r'[^a-z0-9\s]', ' ', question.lower())
        words = [w for w in clean.split()
                 if w and len(w) > 2 and w not in STOP_WORDS]
        for word in words:
            if word not in index:
                index[word] = {}
            index[word][ecode] = index[word].get(ecode, 0) + 1
    return index


def resolve_symptom(symptom: str, symptom_to_ecode: dict, keyword_index: dict) -> str | None:
    """
    Convert any symptom string to its E-code.

    Priority:
      1. Direct E-code pattern  →  return as-is
      2. Exact full-question    →  lookup in symptom_to_ecode
      3. Keyword scoring        →  best match from keyword_index
    """
    if not symptom:
        return None

    s = symptom.strip()

    # 1. Already an E-code
    if re.match(r'^E_\d+', s, re.IGNORECASE):
        return s

    # 2. Exact question match
    if s in symptom_to_ecode:
        return symptom_to_ecode[s]

    # 3. Keyword scoring
    clean = re.sub(r'[^a-z0-9\s]', ' ', s.lower())
    words = [w for w in clean.split() if w and len(w) > 2 and w not in STOP_WORDS]

    if not words:
        return None

    ecode_scores = {}
    for word in words:
        if word in keyword_index:
            for ecode, freq in keyword_index[word].items():
                ecode_scores[ecode] = ecode_scores.get(ecode, 0) + 1

    if not ecode_scores:
        return None

    return max(ecode_scores, key=lambda e: ecode_scores[e])


# ─────────────────────────────────────────────
#  Main predictor
# ─────────────────────────────────────────────
class LogicPredictor:
    def __init__(self, conditions_path, evidences_path, translations_path, symptom_map_path):
        with open(conditions_path, 'r', encoding='utf-8') as f:
            self.conditions = json.load(f)

        self.evidences = {}
        if os.path.exists(evidences_path):
            with open(evidences_path, 'r', encoding='utf-8') as f:
                self.evidences = json.load(f)

        self.symptom_to_ecode = {}
        if os.path.exists(symptom_map_path):
            with open(symptom_map_path, 'r', encoding='utf-8') as f:
                self.symptom_to_ecode = json.load(f)

        self.keyword_index = build_keyword_index(self.symptom_to_ecode)

        self.translations = {}
        if os.path.exists(translations_path):
            with open(translations_path, 'r', encoding='utf-8') as f:
                self.translations = json.load(f)

        log_debug(f"Loaded {len(self.conditions)} diseases | "
                  f"{len(self.symptom_to_ecode)} symptom questions | "
                  f"{len(self.keyword_index)} keyword entries")

    def _resolve_all(self, items: list) -> dict:
        """Resolve a list of symptoms/ecodes → {ecode: original_input}"""
        resolved = {}
        for item in items:
            if not item:
                continue
            ecode = resolve_symptom(str(item), self.symptom_to_ecode, self.keyword_index)
            if ecode:
                resolved[ecode] = str(item)
        return resolved

    def predict(self, input_data):
        if isinstance(input_data, dict):
            raw_evidence   = input_data.get("evidence_codes", [])
            raw_symptoms   = input_data.get("symptoms", [])
            age            = input_data.get("age", 30)
            sex            = input_data.get("sex", "M")
        else:
            raw_evidence   = input_data if isinstance(input_data, list) else []
            raw_symptoms   = []
            age            = 30
            sex            = "M"

        resolved = {}
        resolved.update(self._resolve_all(raw_evidence))
        resolved.update(self._resolve_all(raw_symptoms))

        log_debug(f"Input resolved → {resolved}")

        input_ecodes = set(resolved.keys())

        if not input_ecodes:
            return {"error": "No recognizable symptoms found",
                    "disease": "Unknown", "confidence": 0}

        results = []
        for cond_id, cond_data in self.conditions.items():
            cond_symptoms = set(cond_data.get("symptoms", {}).keys())
            if not cond_symptoms:
                continue

            intersection = input_ecodes & cond_symptoms
            union        = input_ecodes | cond_symptoms

            jaccard  = len(intersection) / len(union) if union else 0
            recall   = len(intersection) / len(cond_symptoms)

            # Weighted score (recall biased → rewards covering the disease profile)
            final    = (jaccard * 0.4) + (recall * 0.6)
            confidence = min(round(final * 100, 2), 99.0)

            trans = self.translations.get(cond_id, {})
            results.append({
                "disease":        cond_id,
                "name_ar":        trans.get("name_ar", cond_id),
                "description_ar": trans.get("description_ar", ""),
                "precautions_ar": trans.get("precautions_ar", []),
                "confidence":     confidence,
                "hits":           len(intersection)
            })

        results.sort(key=lambda x: (x["confidence"], x["hits"]), reverse=True)
        top = results[:3]

        if not top or top[0]["confidence"] == 0:
            return {"error": "Low confidence in diagnosis",
                    "disease": "Unknown", "confidence": 0}

        return {
            "disease":       top[0]["disease"],
            "name_ar":       top[0]["name_ar"],
            "confidence":    top[0]["confidence"],
            "top_results":   top,
            "matched_count": len(input_ecodes),
            "resolved":      resolved        # shows what keywords mapped to
        }


# ─────────────────────────────────────────────
#  Persistent process entry point
# ─────────────────────────────────────────────
def main():
    import io
    sys.stdout = io.TextIOWrapper(sys.stdout.buffer, encoding='utf-8')
    sys.stdin  = io.TextIOWrapper(sys.stdin.buffer,  encoding='utf-8-sig')

    data_dir = os.path.dirname(os.path.abspath(__file__))
    paths = {
        "conditions": os.path.join(data_dir, 'conditions.json'),
        "evidences":  os.path.join(data_dir, 'evidences.json'),
        "trans":      os.path.join(data_dir, 'diseases_ar.json'),
        "symmap":     os.path.join(data_dir, 'symptom_to_ecode.json'),
    }

    try:
        predictor = LogicPredictor(
            paths["conditions"], paths["evidences"],
            paths["trans"],      paths["symmap"]
        )
        print("READY")
        sys.stdout.flush()

        for line in sys.stdin:
            line = line.strip()
            if not line:
                continue
            if line.upper() == "EXIT":
                break
            try:
                data   = json.loads(line)
                result = predictor.predict(data)
                print(json.dumps(result, ensure_ascii=False))
                sys.stdout.flush()
            except Exception as e:
                print(json.dumps({"error": f"Inference error: {str(e)}"}))
                sys.stdout.flush()

    except Exception as e:
        log_debug(f"STARTUP ERROR: {str(e)}")
        print(json.dumps({"error": f"Startup Error: {str(e)}"}))


if __name__ == "__main__":
    main()
