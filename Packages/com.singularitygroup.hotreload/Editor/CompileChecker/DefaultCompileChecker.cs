#if UNITY_2019_1_OR_NEWER
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.Compilation;

namespace SingularityGroup.HotReload.Editor
{
    internal class DefaultCompileChecker : ICompileChecker
    {
        private const string recompileFilePath = PackageConst.LibraryCachePath + "/recompile.txt";

        private Action _onCompilationFinished;
        private bool recompile;

        public DefaultCompileChecker()
        {
            CompilationPipeline.assemblyCompilationFinished += DetectCompileErrors;
            CompilationPipeline.compilationFinished += OnCompilationFinished;
            var currentSessionId = EditorAnalyticsSessionInfo.id;
            Task.Run(() =>
            {
                try
                {
                    var compileSessionId = File.ReadAllText(recompileFilePath);
                    if (compileSessionId == currentSessionId.ToString())
                        ThreadUtility.RunOnMainThread(() =>
                        {
                            recompile = true;
                            _onCompilationFinished?.Invoke();
                        });
                    File.Delete(recompileFilePath);
                }
                catch (DirectoryNotFoundException)
                {
                    //dir doesn't exist -> no recompile required
                }
                catch (FileNotFoundException)
                {
                    //file doesn't exist -> no recompile required
                }
                catch (Exception ex)
                {
                    Log.Warning("compile checker encountered issue: {0} {1}", ex.GetType().Name, ex.Message);
                }
            });
        }

        public bool hasCompileErrors { get; private set; }

        public event Action onCompilationFinished
        {
            add
            {
                if (recompile && value != null) value();
                _onCompilationFinished += value;
            }
            remove => _onCompilationFinished -= value;
        }

        private void DetectCompileErrors(string _, CompilerMessage[] messages)
        {
            for (var i = 0; i < messages.Length; i++)
                if (messages[i].type == CompilerMessageType.Error)
                {
                    hasCompileErrors = true;
                    return;
                }

            hasCompileErrors = false;
        }

        private void OnCompilationFinished(object _)
        {
            //Don't recompile on compile errors
            if (!hasCompileErrors)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(recompileFilePath));
                File.WriteAllText(recompileFilePath, EditorAnalyticsSessionInfo.id.ToString());
            }
        }
    }
}
#endif