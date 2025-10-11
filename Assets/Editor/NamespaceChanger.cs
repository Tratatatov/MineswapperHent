using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class NamespaceChanger : EditorWindow
{
    private string newNamespace = "YourNamespace"; // �������� �� ���� ������������ ����

    private void OnGUI()
    {
        GUILayout.Label("Change Namespace for Selected Scripts", EditorStyles.boldLabel);
        newNamespace = EditorGUILayout.TextField("New Namespace", newNamespace);

        if (GUILayout.Button("Apply Namespace")) ApplyNamespaceToSelectedScripts();
    }

    [MenuItem("Tools/Namespace Changer")]
    public static void ShowWindow()
    {
        GetWindow<NamespaceChanger>("Namespace Changer");
    }

    private void ApplyNamespaceToSelectedScripts()
    {
        foreach (var obj in Selection.objects)
            if (obj is MonoScript monoScript)
            {
                var filePath = AssetDatabase.GetAssetPath(monoScript);
                if (!string.IsNullOrEmpty(filePath))
                {
                    var fileContent = File.ReadAllText(filePath);
                    var newContent = ChangeNamespaceInFile(fileContent, newNamespace);
                    File.WriteAllText(filePath, newContent);
                    AssetDatabase.ImportAsset(filePath);
                }
            }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Namespace changed for selected scripts.");
    }

    private string ChangeNamespaceInFile(string content, string newNamespace)
    {
        var namespacePattern = @"namespace\s+\w+";
        var newContent = Regex.Replace(content, namespacePattern, $"namespace {newNamespace}", RegexOptions.Singleline);

        return newContent;
    }
}