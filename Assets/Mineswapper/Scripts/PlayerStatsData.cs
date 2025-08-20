using System;
using UnityEngine;

namespace HentaiGame
{
    [Serializable]
    public class PlayerStatsData
    {
        [SerializeField] private int _startHp;
        [SerializeField] private int _startCoins;

        private int _hp;
        private int _coins;
        private int _level;
        private int _flags;

        public int Flags { get => _flags; set => _flags = value; }
        public int Level { get => _level; set => _level = value; }
        public int Coins { get => _coins; set => _coins = value; }
        public int Hp { get => _hp; set => _hp = value; }

        public void SetStartValues()
        {
            _hp = _startHp;
            _coins = _startCoins;
            _level = 1;

        }

        public void SetFlagValue(int value)
        {
            _flags = value;
        }

        public void ChangeHp(int count)
        {
            _hp += count;
        }

        public void ChangeCoins(int count)
        {
            _coins += count;
        }

        public void ChangeFlags(int count)
        {
            _flags += count;
        }

        public void IncreaseLevel(int count)
        {
            _level += count;
        }
    }
}
