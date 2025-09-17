using System;
using UnityEngine;

namespace HentaiGame
{
    [Serializable]
    public class PlayerStatsData
    {
        [SerializeField] private int _startHp;
        [SerializeField] private int _startMoney;

        [SerializeField] private int _flags;


        [SerializeField] private int _hp;
        // [SerializeField] private int _level;
        [SerializeField] private int _money;
        [SerializeField] private int _turns;
        [SerializeField] private int _startTurns;

        public PlayerStatsData(int startHp, int startMoney, int startTurns)
        {
            _startHp = startHp;
            _startMoney = startMoney;
            _startTurns = startTurns;
        }

        public int Turns => _turns;

        public int Flags => _flags;

        // public int Level => _level;

        public int Money => _money;

        public int Hp => _hp;

        public void SetStartValues()
        {
            _hp = _startHp;
            _money = _startMoney;
            // _level = _startLevel;
            _turns = _startTurns;
        }

        public void SetFlagsCount(int value)
        {
            _flags = value;
        }

        public void IncreaseFlags(int count)
        {
            _flags += count;
        }

        public void DecreaseFlags(int count)
        {
            _flags -= count;
        }

        public void IncreaseHp(int count)
        {
            _hp += count;
        }

        public void DecreaseHp(int count)
        {
            _hp -= count;
        }

        public void SetHpCount(int count)
        {
            _hp = count;
        }

        public void SetMoneyCount(int count)
        {
            _money = count;
        }

        public void IncreaseMoney(int count)
        {
            _money += count;
            PlayerProgeress.AddCoins(amount: count);
        }

        public void DecreaseMoney(int count)
        {
            _money -= count;
            PlayerProgeress.DecreaseCoins(amount: count);
        }

        public void IncreaseTurns(int count)
        {
            _turns += count;
        }

        public void DecreaseTurns(int count)
        {
            _turns -= count;
        }

        public void SetTurnsCount(int count)
        {
            _turns = count;
        }

        // public void IncreaseLevel(int count)
        // {
        //     _level += count;
        // }
    }
}