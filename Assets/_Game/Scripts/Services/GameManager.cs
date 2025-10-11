using UnityEngine;
using Zenject;

namespace HentaiGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private BoardConfig _boardConfig;
        private BoardFactory _boardFactory;
        private ChangeSceneService _changeSceneService;
        private PlayerDataLevel _playerDataLevel;
        private SaveManager _saveManager;

        public Board Board { get; private set; }

        public GameOverService GameOverService { get; private set; }

        private void Awake()
        {
            Instance = this;
            Board = _boardFactory.Get(width: _boardConfig.Width, height: _boardConfig.Height,
                numMines: _boardConfig.NumMines);
        }

        private void OnEnable()
        {
            GameEvents.OnTurnOver += _changeSceneService.GoToNextLevel;
            GameEvents.OnTurnOver += () => _saveManager.SaveBetweenLevel(playerDataLevel: _playerDataLevel);
        }

        private void OnDisable()
        {
            GameEvents.OnTurnOver -= _changeSceneService.GoToNextLevel;
            GameEvents.OnTurnOver -= () => _saveManager.SaveBetweenLevel(playerDataLevel: _playerDataLevel);
        }

        [Inject]
        private void Construct(
            BoardConfig boardConfig, BoardFactory boardFactory,
            GameOverService gameOverService,
            ChangeSceneService changeSceneService,
            SaveManager saveManager,
            PlayerDataLevel playerDataLevel)
        {
            _playerDataLevel = playerDataLevel;
            _saveManager = saveManager;
            GameOverService = gameOverService;
            _changeSceneService = changeSceneService;
            _boardConfig = boardConfig;
            _boardFactory = boardFactory;
        }
    }
}