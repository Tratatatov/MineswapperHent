using System;
using UnityEngine;

namespace HentaiGame
{
    public class TurnsService
    {
        private int _turnsLeft;

        public int TurnsLeft => _turnsLeft;

        private Action _onTurnsOver;

        public TurnsService(int turnsLeft, Action onTurnsOver)
        {
            _turnsLeft = turnsLeft;
            _onTurnsOver = onTurnsOver;
        }

        public void MakeTurn()
        {
            _turnsLeft--;
            if (_turnsLeft <= 0) _onTurnsOver?.Invoke();
        }
    }
}