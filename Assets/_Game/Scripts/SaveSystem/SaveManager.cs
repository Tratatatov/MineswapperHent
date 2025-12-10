using System;
using UnityEngine;
using Zenject;

namespace HentaiGame
{
    [Serializable]
    public class SaveManager
    {
        public bool Check;

        [SerializeField] private PlayerData _playerData;
        [SerializeField] private PlayerDataPersistance _playerDataPersistance;

        [Inject]
        public SaveManager(PlayerDataPersistance playerDataPersistance, PlayerData playerData)
        {
            _playerDataPersistance = playerDataPersistance;
            _playerData = playerData;
        }

        public void SaveAll()
        {
            _playerData.Save(dataName: DataName.Coins, value: _playerDataPersistance.Coins);
            _playerData.Save(dataName: DataName.MaxHP, value: _playerDataPersistance.MaxHP);
            _playerData.Save(dataName: DataName.Level, value: _playerDataPersistance.Level);
            _playerData.Save(dataName: DataName.HP, value: _playerDataPersistance.HP);
            _playerData.Save(dataName: DataName.MaxTurns, value: _playerDataPersistance.MaxTurns);
            _playerData.Save(dataName: DataName.HPRegen, value: _playerDataPersistance.HealTurns);
        }

        public void SaveBetweenLevel(PlayerDataLevel playerDataLevel)
        {
            _playerDataPersistance.HP = playerDataLevel.HP;
            _playerDataPersistance.Coins = playerDataLevel.Coins;
            _playerDataPersistance.Level++;
        }


        public void LoadAll()
        {
            _playerDataPersistance.Coins = _playerData.Load(dataName: DataName.Coins);
            _playerDataPersistance.MaxHP = _playerData.Load(dataName: DataName.MaxHP);
            _playerDataPersistance.HP = _playerData.Load(dataName: DataName.HP);
            _playerDataPersistance.MaxTurns = _playerData.Load(dataName: DataName.MaxTurns);
            _playerDataPersistance.HealTurns = _playerData.Load(dataName: DataName.HPRegen);
            _playerDataPersistance.Level = _playerData.Load(dataName: DataName.Level);
        }
        // public void LoadAll()
        // {
        //     _playerDataPersistance.Coins = 0;
        //     _playerDataPersistance.MaxHP = 0;
        //     _playerDataPersistance.HP = 0;
        //     _playerDataPersistance.MaxTurns = 0;
        //     _playerDataPersistance.HPRegen = 0;
        //     _playerDataPersistance.Level = 0;
        // }

        public void Reset()
        {
            _playerData.Reset();
        }
    }
}