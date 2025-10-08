using HentaiGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private PlayerDefaultStatsConfig _playerDefaultStatsConfig;
    [SerializeField] private PlayerDataPersistance _playerDataPersistance;
    [SerializeField] private Button _loadButton;
    [SerializeField] private Button _reloadButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _saveButton;
    private PlayerData _playerData;

    private void Awake()
    {
        _playerData = new PlayerData(playerDefaultStatsConfig: _playerDefaultStatsConfig);

        _loadButton.onClick.AddListener(call: LoadAll);
        _saveButton.onClick.AddListener(call: SaveAll);
        _resetButton.onClick.AddListener(call: _playerData.Reset);
        _reloadButton.onClick.AddListener(() => SceneManager.LoadScene(sceneName: SceneManager.GetActiveScene().name));
    }

    private void Update()
    {
    }

    private void SaveAll()
    {
        _playerData.Save(dataName: DataName.Coins, value: _playerDataPersistance.Coins);
        _playerData.Save(dataName: DataName.MaxHP, value: _playerDataPersistance.MaxHP);
        _playerData.Save(dataName: DataName.Level, value: _playerDataPersistance.Level);
        _playerData.Save(dataName: DataName.HP, value: _playerDataPersistance.HP);
        _playerData.Save(dataName: DataName.MaxTurns, value: _playerDataPersistance.MaxTurns);
        _playerData.Save(dataName: DataName.HPRegen, value: _playerDataPersistance.HPRegen);
    }


    private void LoadAll()
    {
        _playerDataPersistance.Coins = _playerData.Load(dataName: DataName.Coins);
        _playerDataPersistance.MaxHP = _playerData.Load(dataName: DataName.MaxHP);
        _playerDataPersistance.HP = _playerData.Load(dataName: DataName.HP);
        _playerDataPersistance.MaxTurns = _playerData.Load(dataName: DataName.MaxTurns);
        _playerDataPersistance.HPRegen = _playerData.Load(dataName: DataName.HPRegen);
        _playerDataPersistance.Level = _playerData.Load(dataName: DataName.Level);
    }
}