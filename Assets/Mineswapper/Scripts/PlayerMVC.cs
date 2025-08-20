using System;
using UnityEngine;

namespace HentaiGame
{
    public class PlayerMVC : MonoBehaviour
    {
        [SerializeField] private CharacterText _playerView;
        [SerializeField] private PlayerStatsData _playerStats;
        [SerializeField] private CharacterView _characterView;
        public void Initialize(int flagsCount)
        {
            _playerStats.SetStartValues();
            _playerStats.SetFlagValue(flagsCount);
            _characterView.SetStartView();  
            UpdateView();
        }

        private void UpdateView()
        {
            _playerView.SetText(_playerView.HpText, "HP", _playerStats.Hp);
            _playerView.SetText(_playerView.FlagsText, "Flags", _playerStats.Flags);
            _playerView.SetText(_playerView.LevelText, "Level", _playerStats.Level);
            _playerView.SetText(_playerView.CoinsText, "Coins", _playerStats.Coins);
        }

        public void TakeDamage(int count)
        {
            _playerStats.ChangeHp(-count);
            _characterView.PlayDamageEffect(_playerStats.Hp);
            _playerView.SetText(_playerView.HpText, "HP", _playerStats.Hp);
        }

        public void ChangeCoins(int count)
        {
            _playerStats.ChangeCoins(count);
            _playerView.SetText(_playerView.CoinsText, "Coins", _playerStats.Coins);
        }

        public void ChangeFlags(int count)
        {
            _playerStats.ChangeFlags(count);
            _playerView.SetText(_playerView.FlagsText, "Flags", _playerStats.Flags);
        }

        public void IncreaseLevel(int count)
        {
            _playerStats.IncreaseLevel(count);
            _playerView.SetText(_playerView.LevelText, "Level", _playerStats.Level);
        }
    }
}
