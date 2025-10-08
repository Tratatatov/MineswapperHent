using UnityEngine;

namespace HentaiGame
{
    public class SceneBootstrapper : MonoBehaviour, IServiceRegister
    {
        [SerializeField] private SceneInstaller _installer;
        private Board _board;
        private CharacterOnBoard _characterOnBoard;

        private CharacterView _characterView;
        private GameOverService _gameOverService;
        private MoneyService _moneyService;
        private PlayerController _playerController;


        private void Awake()
        {
            Initialize();
            RegisterServices();
        }

        private void Initialize()
        {
            _characterOnBoard = _installer.CharacterOnBoard;
            _characterOnBoard.Initialize(
                characterSpriteRenderer: _installer.CharacterOnBoardSpriteRenderer,
                miniIconSprite: _installer.CharacterSpritesConfig.SmallIconSprite);
            _characterView = new CharacterView(
                characterImagesReferences: _installer.CharacterImagesReferences,
                characterSpritesConfig: _installer.CharacterSpritesConfig,
                animationSpeed: _installer.AnimationSpeedConfig.FaceChangeSpeed,
                coroutineStarter: _installer.CoroutineRunner);

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
            GlobalState.GameState = GameState.GamePlay;
        }

        public void RegisterServices()
        {
            ServiceLocator.Register(service: _gameOverService);
        }
    }
}