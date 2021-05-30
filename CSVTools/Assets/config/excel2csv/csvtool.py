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
    xlsx_file = pandas.read_excel(f"{xlsx_path}/{xlsx_name}")
    xlsx_file.to_csv(f"{csv_path}/{csv_name}", encoding="GB2312")
    print(f"Generate: {csv_path}/{csv_name}")


if __name__ == '__main__':
    eval(sys.argv[1])
