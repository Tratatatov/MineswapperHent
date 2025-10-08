using UnityEngine;
using UnityEngine.SceneManagement;

namespace HentaiGame
{
    public class GameBootstrapper : MonoBehaviour, IServiceRegister, ISceneChanger
    {
        [SerializeField] private GameInstaller _gameInstaller;

        private void Awake()
        {
            RegisterServices();
            DontDestroyOnLoad(target: gameObject);
            ChangeScene();
        }

        public void ChangeScene()
        {
            SceneManager.LoadSceneAsync(sceneName: SceneNameConstants.MainMenu);
        }

        public void RegisterServices()
        {
            ServiceLocator.Register(service: _gameInstaller.SoundManager);
            ServiceLocator.Register(
                new GlobalProgressModelView(defaultStatsConfig: _gameInstaller.PlayerDefaultStatsConfig));
            ServiceLocator.Register(new GlobalProgressModel());
        }
    }

    public interface ISceneChanger
    {
        void ChangeScene();
    }
}

public class SceneNameConstants
{
    public const string Bootstrap = "Bootstrap";
    public const string MainMenu = "MainMenu";
    public const string PerksMenu = "PerksMenu";
}