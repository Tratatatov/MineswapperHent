using UnityEditor;
using UnityEngine;

namespace SingularityGroup.HotReload.Editor.ProjectGeneration
{
    internal class ProjectGenenerationPostProcessor : AssetPostprocessor
    {
        // Called once before any generation of sln/csproj files happens, can return true to disable generation altogether
        private static bool OnPreGeneratingCSProjectFiles()
        {
            ProjectGeneration.GenerateSlnAndCsprojFiles(Application.dataPath).Forget();
            return false;
        }
    }
}