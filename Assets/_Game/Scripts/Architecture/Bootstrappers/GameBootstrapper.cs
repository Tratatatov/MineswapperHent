using UnityEngine;
using UnityEngine.SceneManagement;

namespace HentaiGame
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameInstaller _gameInstaller;
        private ChangeSceneService _changeSceneService;
        private PlayerData _playerData;
        private PlayerDataPersistance _playerDataPersistance;
        private SaveManager _saveManager;

        private void Awake()
        {
            CreateObjects();
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
            ServiceLocator.Register(service: _changeSceneService);
            ServiceLocator.Register(service: _gameInstaller.SoundManager);
            ServiceLocator.Register(_playerData =
                new PlayerData(playerDefaultStatsConfig: _gameInstaller.PlayerDefaultStatsConfig));
            ServiceLocator.Register(_playerDataPersistance = new PlayerDataPersistance());
            ServiceLocator.Register(service: _saveManager);
        }

        public void CreateObjects()
        {
            _changeSceneService = new ChangeSceneService();
            _playerData = new PlayerData(playerDefaultStatsConfig: _gameInstaller.PlayerDefaultStatsConfig);
            _playerDataPersistance = new PlayerDataPersistance();
            _saveManager = new SaveManager(playerDataPersistance: _playerDataPersistance, playerData: _playerData);
        }
    }
}