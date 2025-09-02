namespace SingularityGroup.HotReload.Editor.Cli
{
    internal class StartArgs
    {
        public string cliArguments;

        // aka method patch temp dir
        public string cliTempDir;
        public bool createNoWindow;
        public string executableSourceDir;
        public string executableTargetDir;
        public string hotreloadTempDir;
        public string unityProjDir;
    }
}