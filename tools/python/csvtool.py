import os
import pandas


def excel_to_csv_all(config_path: str):
    xlsx_list = []
    file_list = os.listdir(config_path)
    for filename in file_list:
        if filename.endswith(".xlsx"):
            xlsx_list.append(filename)
    for filename in xlsx_list:
        csv_name = filename.split("-")[0] + ".csv"
        xlsx_file = pandas.read_excel(filename)
        xlsx_file.to_csv(csv_name, encoding="GB2312")


def excel_to_csv(config_path: str, xlsx_name: str):
    csv_name = xlsx_name.split("-")[0] + ".csv"
    xlsx_file = pandas.read_excel(xlsx_name)
    xlsx_file.to_csv(csv_name, encoding="GB2312")



