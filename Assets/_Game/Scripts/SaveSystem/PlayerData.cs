using System;
using UnityEngine;

namespace HentaiGame
{
    [Serializable]
    public class PlayerData
    {
        public bool Check;

        private PlayerDefaultStatsConfig _playerDefaultStatsConfig;

        public PlayerData(PlayerDefaultStatsConfig playerDefaultStatsConfig)
        {
            _playerDefaultStatsConfig = playerDefaultStatsConfig;
        }


        // [Inject]
        // public void Construct(PlayerDefaultStatsConfig playerDefaultStatsConfig)
        // {
        //     _playerDefaultStatsConfig = playerDefaultStatsConfig;
        // }


        public int Load(string dataName)
        {
            if (PlayerPrefs.HasKey(key: dataName)) return PlayerPrefs.GetInt(key: dataName);

            if (dataName == DataName.Coins) return 0;
            if (dataName == DataName.Level) return 1;
            if (dataName == DataName.MaxHP) return _playerDefaultStatsConfig.MaxHp;
            if (dataName == DataName.MaxTurns) return _playerDefaultStatsConfig.MaxTurns;
            if (dataName == DataName.HPRegen) return 0;
            if (dataName == DataName.HP) return _playerDefaultStatsConfig.MaxHp;

            throw new ArgumentException($"Неверное имя данных: {dataName}", nameof(dataName));
        }


        public void Save(string dataName, int value)
        {
            PlayerPrefs.SetInt(key: dataName, value: value);
            PlayerPrefs.Save();
        }


        public void Reset()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}