#if ENABLE_MONO && (DEVELOPMENT_BUILD || UNITY_EDITOR)
using System;
using System.Collections;
using UnityEngine;

namespace SingularityGroup.HotReload
{
    internal class AppCallbackListener : MonoBehaviour
    {
        public static AppCallbackListener I { get; private set; }

        public bool Paused { get; private set; }

        private void OnApplicationFocus(bool playing)
        {
            onApplicationFocus?.Invoke(playing);
        }

        private void OnApplicationPause(bool paused)
        {
            Paused = paused;
            onApplicationPause?.Invoke(paused);
        }

        /// <summary>
        ///     Reliable on Android and in the editor.
        /// </summary>
        /// <remarks>
        ///     On iOS, OnApplicationPause is not called at expected moments
        ///     if the app has some background modes enabled in PlayerSettings -Troy.
        /// </remarks>
        public static event Action<bool> onApplicationPause;

        /// <summary>
        ///     Reliable on Android, iOS and in the editor.
        /// </summary>
        public static event Action<bool> onApplicationFocus;

        // Must be called early from Unity main thread (before any usages of the singleton I).
        public static AppCallbackListener Init()
        {
            if (I) return I;
            var go = new GameObject("AppCallbackListener");
            go.hideFlags |= HideFlags.HideInHierarchy;
            DontDestroyOnLoad(go);
            return I = go.AddComponent<AppCallbackListener>();
        }

        public void DelayedQuit(float seconds)
        {
            StartCoroutine(delayedQuitRoutine(seconds));
        }

        private IEnumerator delayedQuitRoutine(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Application.Quit();
        }
    }
}
#endif