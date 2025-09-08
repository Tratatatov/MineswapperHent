namespace HentaiGame
{
    public class GameEventMediator
    {
        private PlayerMVC _playerMvc;
        
        private GameStateService _gameStateService;
        
        public GameEventMediator(GameStateService gameStateService, PlayerMVC playerMvc)
        {
            _gameStateService = gameStateService;
            _playerMvc = playerMvc;
        }

        public void Initialize()
        {
            GameEvents.OnGameOver += _gameStateService.ShowGameOverScreen;
            GameEvents.OnPlayerTurnsOver += _gameStateService.ShowGameOverScreen;
                
        }
        
        private void AddListeners()
        {
            GameEvents.OnGameOver += _gameStateService.ShowGameOverScreen;
            GameEvents.OnPlayerTurnsOver +=  _gameStateService.ShowGameOverScreen;;
        }

        public void RemoveListeners()
        {
            //GameEvents.OnPlayerTurnOver -= _playerMvc.OnPlayerTurnOver;
            GameEvents.OnGameOver -= _gameStateService.ShowGameOverScreen;
        }

        // public void FinishPlayerTurn()
        // {
        //     GameEvents.OnPlayerTurnOver?.Invoke();
        // }

        // public void GameOver()
        // {
        //     GameEvents.OnGameOver?.Invoke();
        // }

        // public void PlayerMakeTurn()
        // {
        //     _playerMvc.DecreaseTurns();
        //     
        // }
        
        
    }
}