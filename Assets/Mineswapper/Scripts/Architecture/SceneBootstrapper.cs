using UnityEngine;

namespace HentaiGame
{
    public class SceneBootstrapper : MonoBehaviour
    {
        [SerializeField] private SceneInstaller _installer;
        private CharacterView _characterView;
        private Board _board;
        private CharacterOnBoard _characterOnBoard;
        private PlayerMVC _playerMVC;
        private PlayerStatsData _playerStatsData;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _playerStatsData = new PlayerStatsData(
                _installer.StartSetupConfig.StartHp,
                _installer.StartSetupConfig.StartGold,
                1
            );
            _characterOnBoard = _installer.CharacterOnBoard;
            _characterOnBoard.Initialize(
                _installer.CharacterOnBoardSpriteRenderer,
                _installer.CharacterSpritesConfig.SmallIconSprite);
            _characterView = new CharacterView(
                _installer.CharacterImagesReferences,
                _installer.CharacterSpritesConfig,
                _installer.AnimationSpeedConfig.FaceChangeSpeed,
                _installer.CoroutineRunner);
            _playerMVC = new PlayerMVC(
                _installer.CharacterTextReferences,
                _playerStatsData,
                _characterView);
            _playerMVC.Initialize(_installer.BoardConfig.NumMines);
            _board = new Board(_installer.BoardConfig,
                _installer.TilePrefab,
                _installer.TilesHolder,
                _characterOnBoard,
                _installer.TileSpritesData);
            _board.CreateGameBoard(
                _installer.BoardConfig.Width,
                _installer.BoardConfig.Height,
                _installer.BoardConfig.NumMines);
            _board.ResetGameState();
        }
    }
}