using UnityEditor;
using UnityEngine;

namespace Editor.CodeTemplate
{
    public class ExcelToCsvWindow : EditorWindow
    {
        private string _fileName;

        private void OnGUI()
        {
            GUILayout.Label("将Excel文件名复制填入：");
            _fileName = GUILayout.TextField(_fileName);
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("确定", GUILayout.Width(100), GUILayout.Height(33)))
            {
                CsvTool.DoExcelToCsv(_fileName);
                Close();
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

        }
    }
}
