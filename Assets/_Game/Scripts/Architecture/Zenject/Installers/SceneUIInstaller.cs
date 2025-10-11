using UnityEngine;
using Zenject;

namespace HentaiGame
{
    public class SceneUIInstaller : MonoInstaller
    {
        [SerializeField] private CharacterImagesReferences _characterImagesReferences;
        [SerializeField] private CharacterSpritesConfig _characterSpritesConfig;
        [SerializeField] private AnimationSpeedConfig _animationSpeedConfig;
        [SerializeField] private CharacterStatsView _characterStatsView;
        [SerializeField] private GameOverMenu _gameOverMenu;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private CoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            Container.Bind<CharacterImagesReferences>().FromInstance(instance: _characterImagesReferences);
            Container.Bind<CharacterSpritesConfig>().FromInstance(instance: _characterSpritesConfig);
            Container.Bind<AnimationSpeedConfig>().FromInstance(instance: _animationSpeedConfig);
            Container.Bind<CharacterStatsView>().FromInstance(instance: _characterStatsView);
            Container.Bind<GameOverMenu>().FromInstance(instance: _gameOverMenu);
            Container.Bind<GameOverScreen>().FromInstance(instance: _gameOverScreen);
            Container.Bind<CoroutineRunner>().FromInstance(instance: _coroutineRunner);
        }
    }
}