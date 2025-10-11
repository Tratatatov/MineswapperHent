using System.IO;
using SingularityGroup.HotReload.Demo;
using Unity.CodeEditor;
using UnityEditor;
using UnityEngine;

namespace SingularityGroup.HotReload.Editor.Demo
{
    internal class EditorDemo : IDemo
    {
        public bool IsServerRunning()
        {
            return ServerHealthCheck.I.IsServerHealthy;
        }

        public void OpenHotReloadWindow()
        {
            HotReloadWindow.Open();
        }

        public void OpenScriptFile(TextAsset textAsset, int line, int column)
        {
            var path = Path.GetFullPath(AssetDatabase.GetAssetPath(textAsset));
#if UNITY_2019_4_OR_NEWER
            CodeEditor.CurrentEditor.OpenProject(path, line, column);
#else
            EditorUtility.OpenWithDefaultApp(path);
#endif
        }
    }
}