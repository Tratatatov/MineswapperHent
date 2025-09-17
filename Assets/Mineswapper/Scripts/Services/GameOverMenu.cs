using System;
using UnityEngine;
using UnityEngine.UI;

namespace HentaiGame
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Button _resetGame;
        [SerializeField] private Button _goToMainMenu;

        private void OnEnable()
        {
            _resetGame.onClick.AddListener(call: ChangeSceneService.ResetLevel);
            _goToMainMenu.onClick.AddListener(call: ChangeSceneService.GoToMainMenu);
        }

        private void OnDisable()
        {
            _resetGame.onClick.RemoveListener(call: ChangeSceneService.ResetLevel);
            _goToMainMenu.onClick.RemoveListener(call: ChangeSceneService.GoToMainMenu);
        }

    }
}