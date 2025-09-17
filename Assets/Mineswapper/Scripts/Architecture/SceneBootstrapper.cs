using UnityEngine;

namespace HentaiGame
{
    public class SceneBootstrapper : MonoBehaviour
    {
        [SerializeField] private SceneInstaller _installer;
        [SerializeField] private PlayerStatsData _playerStatsData;
        private Board _board;
        private CharacterOnBoard _characterOnBoard;

        private CharacterView _characterView;
        private GameOverService _gameOverService;
        private MoneyService _moneyService;
        private PlayerController _playerController;
        private PlayerMVC _playerMVC;


        private void Awake()
        {
            Initialize();
            RegisterServices();
        }

        private void Initialize()
        {
            _playerStatsData = new PlayerStatsData(
                startHp: _installer.StartSetupConfig.StartHp,
                startMoney: _installer.StartSetupConfig.StartGold,
                1,
                startTurns: _installer.StartSetupConfig.StartTurns
            );
            _characterOnBoard = _installer.CharacterOnBoard;
            _characterOnBoard.Initialize(
                characterSpriteRenderer: _installer.CharacterOnBoardSpriteRenderer,
                miniIconSprite: _installer.CharacterSpritesConfig.SmallIconSprite);
            _characterView = new CharacterView(
                characterImagesReferences: _installer.CharacterImagesReferences,
                characterSpritesConfig: _installer.CharacterSpritesConfig,
                animationSpeed: _installer.AnimationSpeedConfig.FaceChangeSpeed,
                coroutineStarter: _installer.CoroutineRunner);
            _playerMVC = new PlayerMVC(
                characterTextReferences: _installer.CharacterTextReferences,
                playerStatsData: _playerStatsData,
                characterView: _characterView
            );
            _playerMVC.Initialize(flagsCount: _installer.BoardConfig.NumMines);
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
            _moneyService = new MoneyService(currentMoney: _installer.StartSetupConfig.StartGold);
            _gameOverService = _installer.GameOverService;
            _gameOverService.Initialize();
            GlobalState.GameState = GameState.GamePlay;
        }

        private void RegisterServices()
        {
            ServiceLocator.Register(service: _playerMVC);
            ServiceLocator.Register(service: _gameOverService);
        }
    }
}