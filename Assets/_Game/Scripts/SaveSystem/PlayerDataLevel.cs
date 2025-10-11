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
        public int HPRegen;
        public int Level;

        [Inject]
        public void Construct(PlayerDataPersistance playerDataPersistance, BoardConfig boardConfig)
        {
            Turns = playerDataPersistance.MaxTurns;
            Flags = boardConfig.NumMines;
            Coins = playerDataPersistance.Coins;
            Level = playerDataPersistance.Level;
            HP = playerDataPersistance.HP;
            HPRegen = playerDataPersistance.HPRegen;
        }
    }
}