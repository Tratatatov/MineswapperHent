using UnityEngine;
using UnityEngine.SceneManagement;

namespace HentaiGame
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameInstaller _gameInstaller;
        private PlayerData _playerData;
        private PlayerDataPersistance _playerDataPersistance;
        private SaveManager _saveManager;
        private ChangeSceneService _changeSceneService;

        private void Awake()
        {
            DontDestroyOnLoad(target: gameObject);
            CreateObjects();
            RegisterServices();
            LoadSaves();
            ChangeScene();
        }

        private void LoadSaves()
        {
            _playerDataPersistance.HP = _playerData.Load(dataName: DataName.HP);
            _playerDataPersistance.Coins = _playerData.Load(dataName: DataName.Coins);
            _playerDataPersistance.MaxTurns = _playerData.Load(dataName: DataName.MaxTurns);
            _playerDataPersistance.MaxHP = _playerData.Load(dataName: DataName.MaxHP);
            _playerDataPersistance.Level = _playerData.Load(dataName: DataName.Level);
            _playerDataPersistance.HPRegen = _playerData.Load(dataName: DataName.HPRegen);
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