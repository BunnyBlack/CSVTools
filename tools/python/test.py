import os
import pandas

all_files = os.listdir(os.getcwd())
csv_list = []
for filename in all_files:
    if filename.endswith(".csv"):
        csv_list.append(filename)

for csv_name in csv_list:
    csv_file = pandas.read_csv(csv_name)
    print(csv_file)
