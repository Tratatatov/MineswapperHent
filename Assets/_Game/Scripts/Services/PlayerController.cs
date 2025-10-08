using UnityEngine;

namespace HentaiGame
{
    public class PlayerController
    {

        //private TurnsService _turnsService;
        private MoneyService _moneyService;
        private CharacterTextReferences _characterTextReferences;

        public PlayerController( MoneyService moneyService,
            CharacterTextReferences characterTextReferences)
        {
            _moneyService = moneyService;
            _characterTextReferences = characterTextReferences;
        }
    }
}