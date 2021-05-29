using UnityEditor;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Editor
{
    public static class CsvTool
    {
        public static string CsvToolName = @"csvtool.py";

        [MenuItem("打表工具/所有Excel转CSV")]
        public static void ExcelToCsvAll()
        {
            DoExcelToCsvAll();
        }

        [MenuItem("打表工具/单个Excel转CSV")]
        public static void ExcelToCsv()
        {

        }

        private static void DoExcelToCsvAll()
        {
            var cmdCommand =
                $"\"{Application.dataPath}/config/excel2csv/{CsvToolName}\" \"excel_to_csv_all('{Application.dataPath}')\"";
            var p = new Process
            {
                StartInfo =
                {
                    //设置要启动的应用程序
                    FileName = "C:\\Users\\86187\\AppData\\Local\\Programs\\Python\\Python39\\python.exe",
                    // 是否使用操作系统shell启动
                    UseShellExecute = false,
                    // 接受来自调用程序的输入信息
                    RedirectStandardInput = true,
                    // 输出信息
                    RedirectStandardOutput = true,
                    // 输出错误
                    RedirectStandardError = true,
                    // 不显示程序窗口
                    CreateNoWindow = false,
                    Arguments = cmdCommand
                }
            };
            //启动程序
            p.Start();
            var outputInfo = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();

            Debug.Log(outputInfo);
            Debug.Log("所有Excel转CSV");
        }
    }
}
