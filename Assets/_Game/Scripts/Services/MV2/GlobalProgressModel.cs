using UnityEngine;

public class GlobalProgressModel
{
    private const string LevelHpRegenSave = "LevelHpRegen";
    private const string MaxTurnsSave = "MaxTurns";
    private const string CoinsSave = "Coins";
    private const string MaxhpSave = "MaxHp";

    public int Coins { get; private set; }

    public int LevelHpRegen { get; private set; }

    public int MaxHp { get; private set; }

    public int MaxTurns { get; private set; }

    public void IncreaseMaxTurns()
    {
        MaxTurns++;
    }

    public void IncreaseMaxHp()
    {
        MaxTurns++;
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
    }

    public bool TryDecreaseCoins(int amount)
    {
        if (Coins >= amount)
        {
            Coins -= amount;
            return true;
        }

        return false;
    }

    public void Save()
    {
        PlayerPrefs.SetInt(key: MaxhpSave, value: MaxHp);
        PlayerPrefs.SetInt(key: CoinsSave, value: Coins);
        PlayerPrefs.SetInt(key: MaxTurnsSave, value: MaxTurns);
        PlayerPrefs.SetInt(key: LevelHpRegenSave, value: LevelHpRegen);
        PlayerPrefs.Save();
    }

    public void TryLoad(int maxDefaultTurns, int maxDefaultHp)
    {
        if (PlayerPrefs.HasKey(key: MaxhpSave)
            && PlayerPrefs.HasKey(key: CoinsSave)
            && PlayerPrefs.HasKey(key: LevelHpRegenSave)
            && PlayerPrefs.HasKey(key: MaxTurnsSave))
        {
            MaxHp = PlayerPrefs.GetInt(key: MaxhpSave);
            Coins = PlayerPrefs.GetInt(key: CoinsSave);
            LevelHpRegen = PlayerPrefs.GetInt(key: LevelHpRegenSave);
            MaxTurns = PlayerPrefs.GetInt(key: MaxTurnsSave);
        }
        else
        {
            MaxHp = maxDefaultHp;
            Coins = 0;
            MaxTurns = maxDefaultTurns;
        }
    }


    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}