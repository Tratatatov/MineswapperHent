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
        [SerializeField] private GameBootstrapper _gameBootstrapper;

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
            _gameBootstrapper.Initialize();
            ChangeSceneService.GoToLevel(1); // Load saved scene
        }
    }
}