using UnityEngine;

namespace HentaiGame
{
    public static class PlayerProgeress
    {
        public static int Coins { get; private set; }

        public static int CurrentLevel { get; private set; }

        public static int LevelHpRegen { get; private set; }

        public static int CurrentHp { get; private set; }
        public static int MaxHp { get; private set; }

        public static int MaxTurns { get; private set; }

        public static void SetStartValues(int turns, int maxHp)
        {
            MaxTurns = turns;
            MaxHp = maxHp;
            Coins = 0;
            CurrentLevel = 1;
            CurrentHp = maxHp;
        }

        public static void IncreaseMaxTurns()
        {
            MaxTurns++;
        }

        public static void IncreaseMaxHp()
        {
            MaxTurns++;
        }
        
        public static void DecreaseHp()
        {
            CurrentHp--;
        }

        public static void IncreaseLevel()
        {
            CurrentLevel++;
        }

        public static void AddCoins(int amount)
        {
            Coins += amount;
        }

        public static void DecreaseCoins(int amount)
        {
            Coins -= amount;
        }

        public static void SaveProgress()
        {
            PlayerPrefs.SetInt("MaxHp", value: MaxHp);
            PlayerPrefs.SetInt("CurrentLevel", value: CurrentLevel);
            PlayerPrefs.SetInt("Coins", value: Coins);
            PlayerPrefs.SetInt("MaxTurns", value: MaxTurns);
            PlayerPrefs.SetInt("LevelHpRegen", value: LevelHpRegen);
            PlayerPrefs.Save();
        }


        public static void LoadProgress()
        {
            MaxHp = PlayerPrefs.GetInt("MaxHp");
            CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
            Coins = PlayerPrefs.GetInt("Coins");
            LevelHpRegen = PlayerPrefs.GetInt("LevelHpRegen");
            MaxTurns = PlayerPrefs.GetInt("MaxTurns");
        }

        public static void ResetProgress(int turns, int maxHp)
        {
            SetStartValues(turns: turns, maxHp: maxHp);
            PlayerPrefs.DeleteAll();
        }

        public static void ResetLevelProgress()
        {
            CurrentLevel = 1;
            PlayerPrefs.SetInt("CurrentLevel",CurrentLevel);
        }
    }
}