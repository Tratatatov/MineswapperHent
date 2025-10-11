using HentaiGame;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private PlayerDefaultStatsConfig _playerDefaultStatsConfig;
    private ChangeSceneService _changeSceneService;
    private PlayerData _playerData;
    private PlayerDataPersistance _playerDataPersistance;
    private SaveManager _saveManager;

    private void CreateObjects()
    {
        _changeSceneService = new ChangeSceneService();
        _playerData = new PlayerData(playerDefaultStatsConfig: _playerDefaultStatsConfig);
        _playerDataPersistance = new PlayerDataPersistance();
        _saveManager = new SaveManager(playerDataPersistance: _playerDataPersistance, playerData: _playerData);
    }

    public override void InstallBindings()
    {
        CreateObjects();
        Container.Bind<SoundManager>().FromInstance(instance: _soundManager).AsSingle();
        Container.Bind<PlayerDefaultStatsConfig>().FromInstance(instance: _playerDefaultStatsConfig).AsSingle();
        Container.Bind<ChangeSceneService>().FromInstance(instance: _changeSceneService).AsSingle();
        Container.Bind<SaveManager>().FromInstance(instance: _saveManager).AsSingle();
        Container.Bind<PlayerData>().FromInstance(instance: _playerData).AsSingle();
        Container.Bind<PlayerDataPersistance>().FromInstance(instance: _playerDataPersistance).AsSingle();
    }
}