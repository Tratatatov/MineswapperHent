using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class NamespaceChanger : EditorWindow
{
    private string newNamespace = "YourNamespace"; // Замените на ваше пространство имен

    [MenuItem("Tools/Namespace Changer")]
    public static void ShowWindow()
    {
        GetWindow<NamespaceChanger>("Namespace Changer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Change Namespace for Selected Scripts", EditorStyles.boldLabel);
        newNamespace = EditorGUILayout.TextField("New Namespace", newNamespace);

        if (GUILayout.Button("Apply Namespace"))
        {
            ApplyNamespaceToSelectedScripts();
        }
    }

    private void ApplyNamespaceToSelectedScripts()
    {
        foreach (var obj in Selection.objects)
        {
            if (obj is MonoScript monoScript)
            {
                string filePath = AssetDatabase.GetAssetPath(monoScript);
                if (!string.IsNullOrEmpty(filePath))
                {
                    string fileContent = File.ReadAllText(filePath);
                    string newContent = ChangeNamespaceInFile(fileContent, newNamespace);
                    File.WriteAllText(filePath, newContent);
                    AssetDatabase.ImportAsset(filePath);
                }
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Namespace changed for selected scripts.");
    }

    private string ChangeNamespaceInFile(string content, string newNamespace)
    {
        string namespacePattern = @"namespace\s+\w+";
        string newContent = Regex.Replace(content, namespacePattern, $"namespace {newNamespace}", RegexOptions.Singleline);

        return newContent;
    }
}
