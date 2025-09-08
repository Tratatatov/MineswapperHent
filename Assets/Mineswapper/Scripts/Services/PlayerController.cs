using UnityEngine;

namespace HentaiGame
{
    public class PlayerController
    {
        private PlayerMVC _playerMVC;
        //private TurnsService _turnsService;
        private MoneyService _moneyService;
        private CharacterTextReferences _characterTextReferences;

        public PlayerController(PlayerMVC playerMvc,  MoneyService moneyService, CharacterTextReferences characterTextReferences)
        {
            _playerMVC = playerMvc;
            _moneyService = moneyService;
            _characterTextReferences = characterTextReferences;
        }
    }
}