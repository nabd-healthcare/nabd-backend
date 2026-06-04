
import json
import re
import os

def clean_question(q):
    if not q: return ""
    # Remove parenthetical info
    q = re.sub(r'\(.*?\)', '', q)
    # Common prefixes
    prefixes = [
        r"^Do you have (a|an|any|some)?\s*",
        r"^Are you (experiencing|feeling|known for|diagnosed with|currently taking|currently using)?\s*",
        r"^Have you (noticed|had|recently had|ever had|recently been|lately felt|been|ever been)?\s*",
        r"^Does the person have (a|an)?\s*",
        r"^Is your\s*",
        r"^Did you\s*",
        r"^Can you\s*",
        r"^Ressentez-vous\s*", # Just in case some French leaked
    ]
    
    cleaned = q
    for p in prefixes:
        cleaned = re.sub(p, "", cleaned, flags=re.IGNORECASE)
    
    # Remove trailing question mark and dots
    cleaned = cleaned.strip("? .")
    # Capitalize first letter
    if cleaned:
        cleaned = cleaned[0].upper() + cleaned[1:]
    return cleaned

def generate():
    data_dir = r"c:\Users\muham\Desktop\Nabd\Back\src\Nabd.Application\AI\Diagnosis\Data"
    evidences_path = os.path.join(data_dir, "evidences.json")
    output_path = os.path.join(data_dir, "symptom_to_ecode.json")
    
    if not os.path.exists(evidences_path):
        print(f"Error: {evidences_path} not found")
        return

    with open(evidences_path, 'r', encoding='utf-8') as f:
        evidences = json.load(f)
        
    mapping = {}
    ecode_to_name = {}
    
    # Manual high-priority short names (Pure English)
    golden_names = {
        "E_91": ["Fever", "High temperature"],
        "E_201": ["Cough", "Chronic cough"],
        "E_66": ["Shortness of breath", "Difficulty breathing", "Dyspnea"],
        "E_133": ["Chest pain", "Upper chest pain"],
        "E_109": ["DVT", "Deep vein thrombosis", "Blood clot in leg"],
        "E_82": ["Dizziness", "Lightheadedness", "Fainting feeling"],
        "E_148": ["Nausea", "Vomiting urge"],
        "E_94": ["Chills", "Shivering"],
        "E_220": ["Pain on deep breath", "Pleuritic pain"],
        "E_154": ["Pale skin", "Paleness"],
        "E_155": ["Palpitations", "Fast heart rate"],
        "E_50": ["Sweating", "Sweating at night", "Night sweats"],
        "E_97": ["Sore throat", "Pain on swallowing"],
        "E_202": ["Whooping cough", "Barking cough"],
        "E_124": ["Asthma"],
        "E_123": ["COPD", "Chronic lung disease"],
        "E_69": ["Diabetes", "Sugar disease"],
        "E_104": ["High blood pressure", "Hypertension"],
        "E_99": ["Migraine"],
        "E_107": ["Stroke", "Brain clot"],
        "E_0": ["Viral infection"],
        "E_204": ["Travel history"],
        "E_162": ["Weight loss", "Involuntary weight loss"],
        "E_42": ["Allergy"],
        "E_55_@_V_101": ["Chest pain", "Upper chest pain"]
    }
    
    for ecode, info in evidences.items():
        q_en = info.get("question_en", "")
        if q_en:
            # 1. Add full question
            mapping[q_en] = ecode
            
            # 2. Add cleaned version
            short = clean_question(q_en)
            if short and len(short) > 2:
                mapping[short] = ecode
                # Use as primary name if not already set
                if ecode not in ecode_to_name:
                    ecode_to_name[ecode] = short
    
    # 3. Add golden names
    for ecode, names in golden_names.items():
        primary = names[0]
        ecode_to_name[ecode] = primary # Overwrite with cleaner manual name
        for name in names:
            mapping[name] = ecode
            mapping[name.lower()] = ecode

    # Add codes themselves to mapping so they still work
    for ecode in evidences.keys():
        mapping[ecode] = ecode
        mapping[ecode.lower()] = ecode

    # Add lowercase versions of everything for flexibility
    all_keys = list(mapping.keys())
    for k in all_keys:
        mapping[k.lower()] = mapping[k]

    with open(output_path, 'w', encoding='utf-8') as f:
        json.dump(mapping, f, ensure_ascii=False, indent=4)
    
    # Save reverse mapping
    reverse_path = os.path.join(data_dir, "ecode_to_name.json")
    with open(reverse_path, 'w', encoding='utf-8') as f:
        json.dump(ecode_to_name, f, ensure_ascii=False, indent=4)
    
    print(f"Successfully generated mapping with {len(mapping)} entries")
    print(f"Successfully generated reverse mapping to {reverse_path}")

if __name__ == "__main__":
    generate()
