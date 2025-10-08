using UnityEngine;

namespace HentaiGame
{
    public class SceneBootstrapper : MonoBehaviour
    {
        [SerializeField] private SceneInstaller _installer;
        private Board _board;
        private CharacterImages _characterImages;
        private CharacterOnBoard _characterOnBoard;
        private CharacterStatsView _characterStatsView;
        private GameOverMenu _gameOverMenu;
        private GameOverService _gameOverService;
        private MoneyService _moneyService;
        private PlayerController _playerController;
        private PlayerDataLevel _playerDataLevel;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _playerDataLevel = new PlayerDataLevel(turns: ServiceLocator.Get<PlayerDataPersistance>().MaxTurns,
                flags: _installer.BoardConfig.NumMines);
            ServiceLocator.Register(service: _playerDataLevel);
            _characterStatsView = _installer.ChatacterStatsView;
            ServiceLocator.Register(service: _characterStatsView);
            _characterOnBoard = _installer.CharacterOnBoard;
            _characterOnBoard.Initialize(
                characterSpriteRenderer: _installer.CharacterOnBoardSpriteRenderer,
                miniIconSprite: _installer.CharacterSpritesConfig.SmallIconSprite);
            _characterImages = new CharacterImages(
                characterImagesReferences: _installer.CharacterImagesReferences,
                characterSpritesConfig: _installer.CharacterSpritesConfig,
                animationSpeed: _installer.AnimationSpeedConfig.FaceChangeSpeed,
                coroutineStarter: _installer.CoroutineRunner);
            _gameOverMenu = _installer.GameOverMenu;
            _gameOverMenu.Initialize(ServiceLocator.Get<ChangeSceneService>());
            _board = new Board(boardConfig: _installer.BoardConfig,
                tilePrefab: _installer.TilePrefab,
                gameHolder: _installer.TilesHolder,
                characterOnBoard: _characterOnBoard,
                tileSpritesData: _installer.TileSpritesDataConfig);
            _board.CreateGameBoard(
                width: _installer.BoardConfig.Width,
                height: _installer.BoardConfig.Height,
                numMines: _installer.BoardConfig.NumMines);
            _board.ResetGameState();
            _gameOverService = _installer.GameOverService;
            _gameOverService.Initialize();
            GameEvents.OnTurnOver += ServiceLocator.Get<ChangeSceneService>().GoToNextLevel;
            GlobalState.GameState = GameState.GamePlay;
        }
    }
}