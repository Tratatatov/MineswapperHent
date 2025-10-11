using UnityEngine;
using UnityEngine.UI;
using Zenject;

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
        private SaveManager _saveManager;

        private void OnEnable()
        {
            _newRunButton.onClick.AddListener(call: StartGame);
        }

        private void OnDisable()
        {
            _newRunButton.onClick.RemoveListener(call: StartGame);
        }

        [Inject]
        private void Construct(ChangeSceneService changeSceneService, SaveManager saveManager)
        {
            _saveManager = saveManager;
            _changeSceneService = changeSceneService;
        }


        private void StartGame()
        {
            _saveManager.LoadAll();
            _changeSceneService.GoToLevel(2); // Load saved scene
        }
    }
}