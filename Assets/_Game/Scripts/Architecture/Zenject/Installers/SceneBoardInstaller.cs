using UnityEngine;
using Zenject;

namespace HentaiGame
{
    public class SceneBoardInstaller : MonoInstaller
    {
        [SerializeField] private BoardConfig _boardConfig;
        [SerializeField] private CharacterOnBoard _characterOnBoard;
        [SerializeField] private GameOverService _gameOverService;
        [SerializeField] private TileSpritesDataConfig _tileSpritesConfig;
        [SerializeField] private TileHolder _tileHolder;
        [SerializeField] private Tile _tilePrefab;

        public override void InstallBindings()
        {
            Container.Bind<Tile>().FromInstance(instance: _tilePrefab).AsSingle();
            Container.Bind<TileFactory>().AsSingle();
            Container.Bind<TileHolder>().FromInstance(instance: _tileHolder).AsSingle();
            Container.Bind<TileSpritesDataConfig>().FromInstance(instance: _tileSpritesConfig).AsSingle();
            Container.Bind<BoardFactory>().AsSingle();
            Container.Bind<PlayerDataLevel>().AsSingle();
            Container.Bind<BoardConfig>().FromInstance(instance: _boardConfig).AsSingle();
            Container.Bind<CharacterOnBoard>().FromInstance(instance: _characterOnBoard).AsSingle();
            Container.Bind<GameOverService>().FromInstance(instance: _gameOverService).AsSingle();
        }
    }
}