using UnityEditor;

namespace SingularityGroup.HotReload.Editor
{
    internal static class HotReloadState
    {
        private const string ServerPortKey = "HotReloadWindow.ServerPort";
        private const string LastPatchIdKey = "HotReloadWindow.LastPatchId";
        private const string ShowingRedDotKey = "HotReloadWindow.ShowingRedDot";
        private const string ShowedEditorsWithoutHRKey = "HotReloadWindow.ShowedEditorWithoutHR";

        private const string RecompiledUnsupportedChangesOnExitPlaymodeKey =
            "HotReloadWindow.RecompiledUnsupportedChangesOnExitPlaymode";

        private const string RecompiledUnsupportedChangesInPlaymodeKey =
            "HotReloadWindow.RecompiledUnsupportedChangesInPlaymode";

        public static int ServerPort
        {
            get => SessionState.GetInt(ServerPortKey, RequestHelper.defaultPort);
            set => SessionState.SetInt(ServerPortKey, value);
        }

        public static string LastPatchId
        {
            get => SessionState.GetString(LastPatchIdKey, string.Empty);
            set => SessionState.SetString(LastPatchIdKey, value);
        }

        public static bool ShowingRedDot
        {
            get => SessionState.GetBool(ShowingRedDotKey, false);
            set => SessionState.SetBool(ShowingRedDotKey, value);
        }

        public static bool ShowedEditorsWithoutHR
        {
            get => SessionState.GetBool(ShowedEditorsWithoutHRKey, false);
            set => SessionState.SetBool(ShowedEditorsWithoutHRKey, value);
        }

        public static bool RecompiledUnsupportedChangesOnExitPlaymode
        {
            get => SessionState.GetBool(RecompiledUnsupportedChangesOnExitPlaymodeKey, false);
            set => SessionState.SetBool(RecompiledUnsupportedChangesOnExitPlaymodeKey, value);
        }

        public static bool RecompiledUnsupportedChangesInPlaymode
        {
            get => SessionState.GetBool(RecompiledUnsupportedChangesInPlaymodeKey, false);
            set => SessionState.SetBool(RecompiledUnsupportedChangesInPlaymodeKey, value);
        }
    }
}