namespace HentaiGame
{
    public class GameStateService
    {
        private GameOverScreen _gameOverScreen;

        public GameStateService(GameOverScreen gameOverScreen)
        {
            _gameOverScreen = gameOverScreen;
        }

        public void ShowGameOverScreen()
        {
            _gameOverScreen.gameObject.SetActive(true);
        }
    }
}