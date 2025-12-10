using HentaiGame;
using TMPro;
using UnityEngine;
using Zenject;

public class CharacterStatsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _flagsText;
    [SerializeField] private TextMeshProUGUI _turnsText;
    [SerializeField] private TextMeshProUGUI _healText; //TODO
    private PlayerDataLevel _playerDataLevel;

    public int HP => _playerDataLevel.HP;

    [Inject]
    private void Construct(PlayerDataLevel playerDataLevel, PlayerDataPersistance playerDataPersistance)
    {
        _playerDataLevel = playerDataLevel;
        UpdateStatsText();
    }

    public void DecreaseTurns()
    {
        _playerDataLevel.Turns--;
        UpdateStatsText();
        if (_playerDataLevel.Turns <= 0) GameEvents.OnTurnsOver?.Invoke();
        // _board.CheckForLevelComplete();
    }

    public void DecreaseHp()
    {
        _playerDataLevel.HP--;
        UpdateStatsText();
        if (_playerDataLevel.HP <= 0) GameEvents.OnGameOver?.Invoke();
    }

    public void DecreaseHp(int count)
    {
        _playerDataLevel.HP -= count;
        if (_playerDataLevel.HP <= 0)
        {
            _playerDataLevel.HP = 0;
            GameEvents.OnGameOver?.Invoke();
            UpdateStatsText();
        }

        UpdateStatsText();
    }

    public void DecreaseCoins(int count)
    {
        _playerDataLevel.Coins -= count;
        if (_playerDataLevel.Coins <= 0) GameEvents.OnCoinsIsNotEnought?.Invoke();

        UpdateStatsText();
    }

    public void InscreaseHp(int count)
    {
        _playerDataLevel.HP += count;
        if (_playerDataLevel.HP > _playerDataLevel.MaxHP) _playerDataLevel.HP = _playerDataLevel.MaxHP;

        UpdateStatsText();
    }

    public void IncreaseFlags()
    {
        _playerDataLevel.Flags++;
        UpdateStatsText();
    }

    public void DecreaseFlags()
    {
        _playerDataLevel.Flags--;
        UpdateStatsText();
    }

    private void UpdateStatsText()
    {
        _turnsText.text = $"Turns: {_playerDataLevel.Turns}";
        _flagsText.text = $"Flags: {_playerDataLevel.Flags}";
        _coinsText.text = $"Coins: {_playerDataLevel.Coins}";
        _levelText.text = $"Level: {_playerDataLevel.Level}";
        _hpText.text = $"HP: {_playerDataLevel.HP}";
        // _healText.text = $"Heal: {_playerDataLevel.HealTurns}";
    }

    public void IncreaseCoins(int count)
    {
        _playerDataLevel.Coins += count;
        UpdateStatsText();
    }

    // public void ResetHealTurns()
    // {
    //     _healText = $"Heal: {0}";
    // }
}