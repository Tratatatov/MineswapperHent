using System;
using Zenject;

namespace HentaiGame
{
    [Serializable]
    public class PlayerDataLevel
    {
        public int Flags;
        public int Turns;
        public int Coins;
        public int HP;
        public int Level;
        public int HealTurns;
        public int TurnsToHeal;
        public int MaxHP;

        [Inject]
        public void Construct(PlayerDataPersistance playerDataPersistance, BoardConfig boardConfig)
        {
            Turns = playerDataPersistance.MaxTurns;
            Flags = boardConfig.NumMines;
            Coins = playerDataPersistance.Coins;
            Level = playerDataPersistance.Level;
            MaxHP = playerDataPersistance.MaxHP;
            HP = playerDataPersistance.HP;
            HealTurns = playerDataPersistance.HealTurns;
        }
    }
}