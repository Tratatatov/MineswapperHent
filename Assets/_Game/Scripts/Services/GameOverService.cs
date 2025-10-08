using UnityEngine;

namespace HentaiGame
{
    public class GameOverService : MonoBehaviour
    {
        [SerializeField] private GameOverScreen _gameOverScreen;

        public void Initialize()
        {
            _gameOverScreen.gameObject.SetActive(false);
            GameEvents.OnGameOver += GameOver;
        }

        private void GameOver()
        {
            _gameOverScreen.gameObject.SetActive(true);
            GlobalState.GameState = GameState.GameOver;
        }
    }
}