using HentaiGame;
using UnityEngine;

public class RunProgressModel
{
    private int _currentHp;
    private int _currentLevel;

    public RunProgressModel(int currentHp, int currentLevel)
    {
        _currentHp = currentHp;
        _currentLevel = currentLevel;
    }

    public int CurrentHp
    {
        get => _currentHp;

        private set
        {
            if (value < 0) value = 0;
            _currentHp = value;
        }
    }

    public int CurrentLevel
    {
        get => _currentLevel;
        private set
        {
            if (value < 1)
            {
                value = 1;
                Debug.LogError("Минимальный уровень - 1");
            }

            _currentLevel = value;
        }
    }

    public void Reset()
    {
        CurrentLevel = 1;
        PlayerPrefs.SetInt("CurrentLevel", value: CurrentLevel);
    }

    public bool TryLoad()
    {
        if (PlayerPrefs.HasKey("CurrentLevel")
            && PlayerPrefs.HasKey("CurrentHp"))
        {
            _currentHp = PlayerPrefs.GetInt("CurrentHp");
            _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            return true;
        }
        
        // Debug.LogError("У тебя нет сохранений");
        return false;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CurrentLevel", value: CurrentLevel);
        PlayerPrefs.SetInt("CurrentHp", value: CurrentHp);
    }

    public bool TryDecreaseHp(int amount)
    {
        if (CurrentHp > amount)
        {
            CurrentHp--;
            GameEvents.OnHpChanged?.Invoke();
            return true;
        }

        return false;
    }

    public void SetHp(int count)
    {
        CurrentHp = count;
        GameEvents.OnHpChanged?.Invoke();
    }

    public void IncreaseLevel()
    {
        CurrentLevel++;
        GameEvents.OnLevelChanged?.Invoke();
    }

    public void SetLevel(int count)
    {
        CurrentLevel = count;
        GameEvents.OnLevelChanged?.Invoke();
    }
}