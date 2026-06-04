# 🧠 Nabd AI Diagnosis System - Architecture Documentation

## 📋 Overview
The Nabd AI Diagnosis System is a **high-performance, local-first** medical inference engine. It is designed to provide rapid, accurate disease prediction based on user symptoms without relying on external APIs for the core logic.

The system uses a **Hybrid Architecture**:
1.  **.NET 8 Backend**: Handles validation, normalization, and logic orchestration.
2.  **Persistent Python Subprocess**: Runs a pre-trained TensorFlow/Keras model in "Interactive Mode" for millisecond-level inference.

---

## 🏗️ Architecture Diagram

```mermaid
graph TD
    UserInput[User Input String] -->|Parse| SimpleSymptomParser
    
    subgraph "Normalization Pipeline (C#)"
        SimpleSymptomParser -->|1. Split| Tokens
        Tokens -->|2. Canonical Normalize| NormalizedTokens[Normalized (lower, trim)]
        NormalizedTokens -->|3. Alias Listing| MappedTokens[Mapped Symptoms]
        MappedTokens -->|4. Schema Filter| ValidatedSymptoms[Final Model Input]
    end
    
    subgraph "Inference Engine (Python)"
        ValidatedSymptoms -->|JSON IPC| PersistentPythonProcess[predict.py (Running Loop)]
        PersistentPythonProcess -->|TensorFlow Model| DiseasePrediction
    end
    
    DiseasePrediction -->|JSON Result| DiagnosisService
    DiagnosisService -->|Response| UserOutput
```

---

## 🔧 Core Components

### 1. The Parser (`SimpleSymptomParser.cs`)
**Role:** Converts raw user text into strict model-compatible features.
*   **Path:** `src/Nabd.Application/Services/AI/SimpleSymptomParser.cs`
*   **Logic:**
    1.  **Tokenization**: Splits input by comma or newline.
    2.  **Canonical Normalization**: Trims whitespace, lowercases text, removes duplicate spaces.
    3.  **Alias Bridge**: Maps common terms (e.g., "chest pain", "shortness of breath") to the specific terms required by the model (e.g., "sharp chest pain", "difficulty breathing").
    4.  **Schema Validation**: Strictly filters out any symptom not present in `symptoms_schema.json`.

### 2. The Model Host (`MainDiagnosisLocalModel.cs`)
**Role:** Manages the lifecycle of the Python AI engine.
*   **Path:** `src/Nabd.Application/AI/Diagnosis/MainDiagnosisLocalModel.cs`
*   **Key Feature: Persistent Process**:
    *   Instead of starting Python for every request (which takes ~20s), it starts **once** and keeps the process alive.
    *   Communicates via `StandardInput` and `StandardOutput` (IPC).
    *   **Performance:** < 100ms per prediction after warm-up.
    *   **Resiliency:** Auto-restarts the process if it crashes or hangs.

### 3. The Inference Script (`predict.py`)
**Role:** The actual AI Brain.
*   **Path:** `AIModels/Main/predict.py`
*   **Stack:** TensorFlow 2.10+, Keras, NumPy.
*   **Modes:**
    *   **Interactive (Default):** Enters a `while True` loop, waiting for JSON input on `stdin`, and printing JSON output to `stdout`.
    *   **One-Shot:** Can be called with arguments for testing (legacy support).
*   **Assets:**
    *   `best_disease_model.h5`: The trained Neural Network.
    *   `symptom_cols.pkl`: Ordered list of 377 supported symptoms.
    *   `label_encoder.pkl`: Mapping of output integers to Disease Names.

---

## 📂 File Structure

| Path                                      | Description                                      |
| ----------------------------------------- | ------------------------------------------------ |
| `Back/AIModels/Main/`                     | **Root AI Directory**                            |
| ├── `predict.py`                          | The Python Inference Script.                     |
| ├── `symptoms_schema.json`                | **Source of Truth** for allowed symptoms.        |
| ├── `best_disease_model.h5`               | The Binary Model File.                           |
| └── `requirements.txt`                    | Python dependencies (tensorflow, numpy).         |
| `src/Nabd.Application/Services/AI/`       | **C# Parsing Layer**                             |
| ├── `SimpleSymptomParser.cs`              | Normalization & Mapping Logic.                   |
| └── `CanonicalSymptomNormalizer.cs`       | String cleanup utilities.                        |
| `src/Nabd.Application/AI/Diagnosis/`      | **C# Model Integration**                         |
| └── `MainDiagnosisLocalModel.cs`          | Process Manager & Interface implementation.      |

---

## 🚀 How to Run & Test
### Prerequisites
1.  Python 3.9+ installed and added to PATH.
2.  Dependencies installed: `pip install -r Back/AIModels/Main/requirements.txt`

### Testing Manually (Backend)
You can test the logic by sending a POST request to the API:
*   **Endpoint:** `POST /api/Doctor/diagnosis`
*   **Body:**
    ```json
    {
      "patientId": "...",
      "symptomsText": "chest pain, shortness of breath, palpitations"
    }
    ```
*   **Expected Behavior:**
    *   The `chest pain` will be mapped to `sharp chest pain`.
    *   The model will receive the valid JSON array.
    *   Response will return `Heart failure` (or similar) with high confidence.

---

## ⚠️ Known Constraints & Rules
1.  **Exact English Terms:** The model currently only accepts English medical terms (or their mapped aliases). Arabic support is in the roadmap (via Gemini Translation Bridge).
2.  **Symptom Count:** A minimum of **2 Valid Model-Aware Symptoms** is required to trigger a diagnosis.
3.  **Parsing Strictness:** Inputting random text or unrecognized symptoms will result in them being filtered out. If the remaining count < 2, the system returns "Insufficient Data".

## 🔮 Future Roadmap
- [ ] **Arabic Bridge:** Implement a lightweight Gemini/LLM step to translate Arabic colloquial descriptions into the standardized English CSV format expected by this system.
