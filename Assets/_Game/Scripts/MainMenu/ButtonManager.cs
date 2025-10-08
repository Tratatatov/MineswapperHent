using UnityEngine;
using UnityEngine.UI;

namespace HentaiGame
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField] private Button _newRunButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _marketButton;

        private void OnEnable()
        {
            _newRunButton.onClick.AddListener(call: StartGame);
        }

        private void OnDisable()
        {
            _newRunButton.onClick.RemoveListener(call: StartGame);
        }


        private void StartGame()
        {
            ChangeSceneService.GoToLevel(2); // Load saved scene
        }
    }
}