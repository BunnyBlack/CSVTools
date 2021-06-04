import os
import sys

import pandas


def excel_to_csv_all(data_path: str):
    xlsx_path = data_path + "/config/xlsx"
    csv_path = data_path + "/config/csv"
    xlsx_list = []
    file_list = os.listdir(xlsx_path)
    for filename in file_list:
        if filename.endswith(".xlsx"):
            xlsx_list.append(filename)
    for filename in xlsx_list:
        csv_name = filename.split("-")[0] + ".csv"
        xlsx_file = pandas.read_excel(f"{xlsx_path}/{filename}")
        xlsx_file.to_csv(f"{csv_path}/{csv_name}", encoding="GB2312")
        print(f"Generate: {csv_path}/{csv_name}")
    print("Complete")


def excel_to_csv(data_path: str, xlsx_name: str):
    xlsx_path = data_path + "/config/xlsx"
    csv_path = data_path + "/config/csv"
    csv_name = xlsx_name.split("-")[0] + ".csv"
    xlsx_name = f"{xlsx_path}/{xlsx_name}"
    if not xlsx_name.endswith(".xlsx"):
        xlsx_name = xlsx_name + ".xlsx"
    xlsx_file = pandas.read_excel(xlsx_name)
    xlsx_file.to_csv(f"{csv_path}/{csv_name}", encoding="GB2312")
    print(f"Generate: {csv_path}/{csv_name}")


def csv_to_json(data_path: str):
    csv_path = data_path + "/config/csv"
    json_path = data_path + "/Scripts/GameSystem/Game/CSVData"
    csv_list = []
    file_list = os.listdir(csv_path)
    for csv_filename in file_list:
        if csv_filename.endswith(".csv"):
            csv_list.append(csv_filename)
    for filename in csv_list:
        json_name = filename.split(".")[0] + ".json"
        csv_file = pandas.read_csv(f"{csv_path}/{filename}")
        csv_file.to_json(f"{json_path}/{json_name}", orient="records")
        print(f"Generate: {json_path}/{json_name}")


if __name__ == '__main__':
    eval(sys.argv[1])

