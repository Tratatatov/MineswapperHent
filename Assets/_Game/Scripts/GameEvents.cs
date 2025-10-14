using System;

namespace HentaiGame
{
    public static class GameEvents
    {
        public static Action OnGameOver;
        public static Action OnPlayerTurnsOver;
        public static Action OnTurnsOver;
        public static Action OnScenesOver;
        public static Action OnCoinsIsNotEnought;

        public static Action OnTurnsChanged;
        public static Action OnFlagsChanged; //TODO:??
        public static Action OnHpChanged;
        public static Action OnLivesChanged;
        public static Action OnMoneyChanged;

        public static Action OnDamageTaken;
        public static Action OnTileOpen;
        public static Action OnFlagPlaced;
        public static Action OnFlagRemoved;
        public static Action OnLevelEnded; //TODO:??
        public static Action OnLevelChanged; //TODO:??
    }
}