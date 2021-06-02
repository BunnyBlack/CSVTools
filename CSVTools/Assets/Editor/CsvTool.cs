using UnityEditor;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LitJson;
using Debug = UnityEngine.Debug;
using File = System.IO.File;

namespace Editor
{
    public static class CsvTool
    {
        private static string _pythonPath = "";
        private const string CsvToolName = @"csvtool.py";

        [MenuItem("打表工具/设置Python位置/自动搜索Python位置")]
        public static void WherePython()
        {
            DoWherePython();
        }
        
        [MenuItem("打表工具/所有Excel转CSV")]
        public static void ExcelToCsvAll()
        {
            DoExcelToCsvAll();
        }

        [MenuItem("打表工具/单个Excel转CSV")]
        public static void ExcelToCsv()
        {

        }


        private static void DoWherePython()
        {
            var p = new Process
            {
                StartInfo =
                {
                    //设置要启动的应用程序
                    FileName = "cmd.exe",
                    // 是否使用操作系统shell启动
                    UseShellExecute = false,
                    // 接受来自调用程序的输入信息
                    RedirectStandardInput = true,
                    // 输出信息
                    RedirectStandardOutput = true,
                    // 输出错误
                    RedirectStandardError = true,
                    // 不显示程序窗口
                    CreateNoWindow = true
                }
            };
            //启动程序
            p.Start();
            p.StandardInput.WriteLine("Where Python&exit");
            var outputInfo = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();

            // 按换行符分开
            var outputStrList = outputInfo.Split('\n');
            // 找到结尾是 python.exe 的字符串作为 python 的路径
            foreach (var outputStr in outputStrList)
            {

                if (!outputStr.Trim().EndsWith("python.exe"))
                    continue;

                // 别忘了去除头尾的空格，否则 process 找不到文件名
                _pythonPath = outputStr.Trim();
                Debug.Log($"Python Path: {_pythonPath}");
                break;
            }
            if (string.IsNullOrEmpty(_pythonPath))
            {
                Debug.LogError("未找到Python路径!");
            }
        }

        private static void DoExcelToCsvAll()
        {
            if (string.IsNullOrEmpty(_pythonPath))
            {
                DoWherePython();
            }

            var cmdCommand =
                $"\"{Application.dataPath}/config/excel2csv/{CsvToolName}\" \"excel_to_csv_all('{Application.dataPath}')\"";
            var p = new Process
            {
                StartInfo =
                {
                    //设置要启动的应用程序
                    FileName = _pythonPath,
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
            AssetDatabase.Refresh();
        }
    }
}
