using System;

namespace HentaiGame
{
    public static class GameEvents
    {
        public static Action OnGameOver;
        public static Action OnPlayerTurnsOver;
        public static Action OnTurnOver;

        // public static void MakeTurn()
        // {
        //     OnPlayerTurnOver?.Invoke();
        // }
        //
        // public static void MakeGameOver()
        // {
        //     OnGameOver?.Invoke();
        // }
        
    }
}