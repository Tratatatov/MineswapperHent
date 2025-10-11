using UnityEngine;
using Zenject;

namespace HentaiGame
{
    public class GameOverService : MonoBehaviour
    {
        [SerializeField] private GameOverScreen _gameOverScreen;

        public bool IsGameOver { get; private set; }

        private void OnEnable()
        {
            GameEvents.OnGameOver += GameOver;
        }

        private void OnDisable()
        {
            GameEvents.OnGameOver -= GameOver;
        }

        [Inject]
        private void Construct()
        {
            _gameOverScreen.gameObject.SetActive(false);
            IsGameOver = false;
        }

        private void GameOver()
        {
            _gameOverScreen.gameObject.SetActive(true);
            IsGameOver = true;
        }
    }
}