import joblib
import os
import psutil
import time

process = psutil.Process(os.getpid())
mem_before = process.memory_info().rss / (1024 * 1024)

t0 = time.time()
model = joblib.load('medical_model.pkl')
t1 = time.time()

mem_after = process.memory_info().rss / (1024 * 1024)

print(f"Model Type: {type(model)}")
print(f"Num Classes: {len(model.classes_) if hasattr(model, 'classes_') else 'N/A'}")
print(f"Num Features: {model.n_features_in_ if hasattr(model, 'n_features_in_') else 'N/A'}")
print(f"Memory Before: {mem_before:.2f} MB")
print(f"Memory After: {mem_after:.2f} MB")
print(f"Estimated Model RAM Usage: {mem_after - mem_before:.2f} MB")
print(f"Load Time: {t1 - t0:.2f} seconds")
