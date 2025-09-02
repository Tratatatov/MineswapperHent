using UnityEngine;

namespace HentaiGame
{
    public class SceneInstaller : MonoBehaviour
    {
        public CharacterOnBoard CharacterOnBoard => _characterOnBoard;

        public BoardConfig BoardConfig => _boardConfig;

        public CharacterSpritesConfig CharacterSpritesConfig => characterSpritesConfig;

        public CharacterTextReferences CharacterTextReferences => characterTextReferences;

        public CharacterImagesReferences CharacterImagesReferences => _characterImagesReferences;

        public TileSpritesData TileSpritesData => _tileSpritesData;

        public AnimationSpeedConfig AnimationSpeedConfig => _animationSpeedConfig;

        public StartSetupConfig StartSetupConfig => _startSetupConfig;

        public Transform TilesHolder => _tilesHolder;
        public Tile TilePrefab => _tilePrefab;

        public SpriteRenderer CharacterOnBoardSpriteRenderer => _characterOnBoardSpriteRenderer;
        public MonoBehaviour CoroutineRunner => _coroutineRunner;

        [SerializeField] private SpriteRenderer _characterOnBoardSpriteRenderer;
        [SerializeField] private MonoBehaviour _coroutineRunner;
        [SerializeField] private TileSpritesData _tileSpritesData;
        [SerializeField] private AnimationSpeedConfig _animationSpeedConfig;
        [SerializeField] private CharacterOnBoard _characterOnBoard;
        [SerializeField] private BoardConfig _boardConfig;
        [SerializeField] private CharacterSpritesConfig characterSpritesConfig;
        [SerializeField] private CharacterTextReferences characterTextReferences;
        [SerializeField] private CharacterImagesReferences _characterImagesReferences;
        [SerializeField] private StartSetupConfig _startSetupConfig;
        [SerializeField] private Tile _tilePrefab;
        [SerializeField] private Transform _tilesHolder;
    }
}