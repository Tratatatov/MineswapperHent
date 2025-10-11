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
    private PlayerDataPersistance _playerDataPersistance;

    public PlayerDataLevel PlayerDataLevel { get; private set; }

    private void Start()
    {
        PlayerDataLevel = ServiceLocator.Get<PlayerDataLevel>();
        _playerDataPersistance = ServiceLocator.Get<PlayerDataPersistance>();
        UpdateStatsText();
    }

    public void DecreaseTurns()
    {
        PlayerDataLevel.Turns--;
        UpdateStatsText();
        if (PlayerDataLevel.Turns <= 0) GameEvents.OnTurnOver?.Invoke();
    }

    public void DecreaseHp()
    {
        _playerDataPersistance.HP--;
        UpdateStatsText();
        if (_playerDataPersistance.HP <= 0) GameEvents.OnGameOver?.Invoke();
    }


    public void InscreaseHp()
    {
        _playerDataPersistance.HP++;
        UpdateStatsText();
    }

    public void IncreaseFlags()
    {
        PlayerDataLevel.Flags++;
        UpdateStatsText();
    }

    public void DecreaseFlags()
    {
        PlayerDataLevel.Flags--;
        UpdateStatsText();
    }

    private void UpdateStatsText()
    {
        _turnsText.text = $"Turns: {PlayerDataLevel.Turns}";
        _flagsText.text = $"Flags: {PlayerDataLevel.Flags}";
        _coinsText.text = $"Coins: {_playerDataPersistance.Coins}";
        _levelText.text = $"Level: {_playerDataPersistance.Level}";
        _hpText.text = $"HP: {_playerDataPersistance.HP}";
    }
}