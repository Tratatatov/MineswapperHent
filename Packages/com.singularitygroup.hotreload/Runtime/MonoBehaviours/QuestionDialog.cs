#if ENABLE_MONO && (DEVELOPMENT_BUILD || UNITY_EDITOR)
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace SingularityGroup.HotReload
{
    internal class QuestionDialog : MonoBehaviour
    {
        [Header("Information")] public Text textSummary;

        public Text textSuggestion;

        [Header("UI controls")] public Button buttonContinue;

        public Button buttonCancel;
        public Button buttonMoreInfo;

        public TaskCompletionSource<bool> completion = new();

        public void UpdateView(Config config)
        {
            textSummary.text = config.summary;
            textSuggestion.text = config.suggestion;

            if (string.IsNullOrEmpty(config.continueButtonText))
            {
                buttonContinue.enabled = false;
            }
            else
            {
                buttonContinue.GetComponentInChildren<Text>().text = config.continueButtonText;
                buttonContinue.onClick.AddListener(() =>
                {
                    completion.TrySetResult(true);
                    Hide();
                });
            }

            if (string.IsNullOrEmpty(config.cancelButtonText))
            {
                buttonCancel.enabled = false;
            }
            else
            {
                buttonCancel.GetComponentInChildren<Text>().text = config.cancelButtonText;
                buttonCancel.onClick.AddListener(() =>
                {
                    completion.TrySetResult(false);
                    Hide();
                });
            }

            buttonMoreInfo.onClick.AddListener(() => { Application.OpenURL(config.moreInfoUrl); });
        }

        /// hide this dialog
        private void Hide()
        {
            gameObject.SetActive(false); // this should disable the Update loop?
        }

        internal class Config
        {
            public string cancelButtonText = "Cancel";
            public string continueButtonText = "Continue";
            public string moreInfoUrl = "https://hotreload.net/documentation#handling-different-commits";
            public string suggestion;
            public string summary;
        }
    }
}
#endif