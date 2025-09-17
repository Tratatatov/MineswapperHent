using System;
using UnityEngine;

namespace HentaiGame
{
    public class SceneInstaller : MonoBehaviour
    {
        // [SerializeField] private StartSetupConfig _startSetupConfig;
        [SerializeField] private TileSpritesData _tileSpritesDataConfig;
        [SerializeField] private CharacterSpritesConfig characterSpritesConfig;
        [SerializeField] private AnimationSpeedConfig _animationSpeedConfig;
        [SerializeField] private BoardConfig _boardConfig;

        [SerializeField] private References _references;
        // public StartSetupConfig StartSetupConfig => _startSetupConfig;

        public AnimationSpeedConfig AnimationSpeedConfig => _animationSpeedConfig;

        public BoardConfig BoardConfig => _boardConfig;

        public TileSpritesData TileSpritesDataConfig => _tileSpritesDataConfig;

        public CharacterSpritesConfig CharacterSpritesConfig => characterSpritesConfig;

        public GameOverService GameOverService => _references.GameOverService;
        public CharacterTextReferences CharacterTextReferences => _references.CharacterTextReferences;

        public CharacterImagesReferences CharacterImagesReferences => _references.CharacterImagesReferences;

        public Transform TilesHolder => _references.TilesHolder;

        public Tile TilePrefab => _references.TilePrefab;

        public SpriteRenderer CharacterOnBoardSpriteRenderer => _references.CharacterOnBoardSpriteRenderer;
        public MonoBehaviour CoroutineRunner => _references.CoroutineRunner;
        public CharacterOnBoard CharacterOnBoard => _references.CharacterOnBoard;
    }

    [Serializable]
    public class References
    {
        [SerializeField] private SpriteRenderer _characterOnBoardSpriteRenderer;
        [SerializeField] private MonoBehaviour _coroutineRunner;
        [SerializeField] private CharacterOnBoard _characterOnBoard;
        [SerializeField] private CharacterTextReferences _characterTextReferences;
        [SerializeField] private CharacterImagesReferences _characterImagesReferences;
        [SerializeField] private Tile _tilePrefab;
        [SerializeField] private Transform _tilesHolder;
        [SerializeField] private GameOverService _gameOverService;

        public GameOverService GameOverService => _gameOverService;

        public CharacterOnBoard CharacterOnBoard => _characterOnBoard;


        public CharacterTextReferences CharacterTextReferences => _characterTextReferences;

        public CharacterImagesReferences CharacterImagesReferences => _characterImagesReferences;

        public Transform TilesHolder => _tilesHolder;

        public Tile TilePrefab => _tilePrefab;

        public SpriteRenderer CharacterOnBoardSpriteRenderer => _characterOnBoardSpriteRenderer;
        public MonoBehaviour CoroutineRunner => _coroutineRunner;
    }
}