using System;
using UnityEngine;

namespace HentaiGame
{
    public class PlayerStatsData
    {
        public PlayerStatsData(int startHp, int startCoins, int level)
        {
            _startHp = startHp;
            _startCoins = startCoins;
            _level = level;
        }

        private int _startHp;
        private int _startCoins;

        private int _flags;


        private int _hp;
        private int _level;
        private int coins;

        public int Flags => _flags;

        public int Level => _level;

        public int Coins => coins;

        public int Hp => _hp;

        public void SetStartValues()
        {
            _hp = _startHp;
            coins = _startCoins;
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
            coins += count;
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