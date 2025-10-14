using UnityEngine;
using Zenject;

namespace HentaiGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private FinalLevelMenu _finalLevelMenu;
        [SerializeField] private NextLevelPanel _nextLevelPanel;
        private BoardConfig _boardConfig;
        private BoardFactory _boardFactory;
        private ChangeSceneService _changeSceneService;
        private CharacterStatsView _characterStatsView;
        private PlayerDataLevel _playerDataLevel;
        private PlayerDataPersistance _playerDataPersistance;
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
            GameEvents.OnTurnsOver += OnTurnsOver;
            GameEvents.OnGameOver += ShowAllTiles;
        }

        private void OnDisable()
        {
            GameEvents.OnGameOver -= ShowAllTiles;
            GameEvents.OnTurnsOver -= OnTurnsOver;
        }

        private void OnTurnsOver()
        {
            ShowAllTiles();
            GameOverService.IsGameOver = true;
            _characterStatsView.DecreaseHp(count: Board.GetClosedMineTiles().Count);
            if (_playerDataLevel.HP > 0)
            {
                _nextLevelPanel.gameObject.SetActive(true);
                _characterStatsView.IncreaseCoins(Board.GetOpenedMineTiles().Count);
                _characterStatsView.DecreaseHp();
                _saveManager.SaveBetweenLevel(playerDataLevel: _playerDataLevel);
            }
        }


        private void ShowAllTiles()
        {
            foreach (Tile tile in Board.Tiles)
                if (tile.IsMine && tile.IsFlagged)
                    tile.ShowMineSafe();
                else if (!tile.IsFlagged && tile.IsMine)
                    tile.ShowMineHit();
                else if (!tile.IsMine) tile.ShowEmpty();
        }

        public void ActivateFinalScreen()
        {
            _finalLevelMenu.gameObject.SetActive(true);
            GameOverService.IsGameOver = true;
        }

        [Inject]
        private void Construct(
            BoardConfig boardConfig, BoardFactory boardFactory,
            GameOverService gameOverService,
            ChangeSceneService changeSceneService,
            SaveManager saveManager,
            PlayerDataLevel playerDataLevel, CharacterStatsView characterStatsView)
        {
            _playerDataLevel = playerDataLevel;
            _saveManager = saveManager;
            GameOverService = gameOverService;
            _changeSceneService = changeSceneService;
            _boardConfig = boardConfig;
            _boardFactory = boardFactory;
            _characterStatsView = characterStatsView;
        }
    }
}