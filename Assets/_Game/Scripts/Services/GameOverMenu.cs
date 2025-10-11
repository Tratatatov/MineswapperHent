using UnityEngine;
using UnityEngine.UI;

namespace HentaiGame
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Button _resetGame;
        [SerializeField] private Button _goToMainMenu;
        private ChangeSceneService _changeSceneService;

        private void OnEnable()
        {
            _resetGame.onClick.AddListener(call: _changeSceneService.ResetLevel);
            _goToMainMenu.onClick.AddListener(call: _changeSceneService.GoToMainMenu);
        }

        private void OnDisable()
        {
            _resetGame.onClick.RemoveListener(call: _changeSceneService.ResetLevel);
            _goToMainMenu.onClick.RemoveListener(call: _changeSceneService.GoToMainMenu);
        }

        public void Initialize(ChangeSceneService changeSceneService)
        {
            _changeSceneService = changeSceneService;
        }
    }
}