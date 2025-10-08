using HentaiGame;
using TMPro;
using UnityEngine;

public class CharacterStatsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _flagsText;
    [SerializeField] private TextMeshProUGUI _turnsText;
    private PlayerDataLevel _playerDataLevel;
    private PlayerDataPersistance _playerDataPersistance;

    public PlayerDataLevel DataLevel => _playerDataLevel;

    private void Start()
    {
        _playerDataLevel = ServiceLocator.Get<PlayerDataLevel>();
        _playerDataPersistance = ServiceLocator.Get<PlayerDataPersistance>();
        UpdateStatsText();
    }

    public void DecreaseTurns()
    {
        _playerDataLevel.Turns--;
        UpdateStatsText();
        if (_playerDataLevel.Turns <= 0) GameEvents.OnTurnOver?.Invoke();
    }

    public void DecreaseHp()
    {
        _playerDataPersistance.HP--;
        UpdateStatsText();
        if (_playerDataLevel.Turns <= 0) GameEvents.OnGameOver?.Invoke();
    }


    public void InscreaseHp()
    {
        _playerDataPersistance.HP++;
        UpdateStatsText();
    }

    public void IncreaseFlags()
    {
        _playerDataLevel.Flags++;
        UpdateStatsText();
    }

    public void  DecreaseFlags()
    {
        _playerDataLevel.Flags--;
        UpdateStatsText();
    }

    private void UpdateStatsText()
    {
        _turnsText.text = $"Turns: {_playerDataLevel.Turns}";
        _flagsText.text = $"Flags: {_playerDataLevel.Flags}";
        _coinsText.text = $"Coins: {_playerDataPersistance.Coins}";
        _levelText.text = $"Level: {_playerDataPersistance.Level}";
        _hpText.text = $"HP: {_playerDataPersistance.HP}";
    }
}