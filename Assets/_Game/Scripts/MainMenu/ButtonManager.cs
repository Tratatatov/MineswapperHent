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
        private ChangeSceneService _changeSceneService;
        private PlayerData _playerData;
        private PlayerDataPersistance _playerDataPersistance;

        private void Start()
        {
            _changeSceneService = ServiceLocator.Get<ChangeSceneService>();
        }

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
            _changeSceneService.GoToLevel(2); // Load saved scene
        }
    }
}