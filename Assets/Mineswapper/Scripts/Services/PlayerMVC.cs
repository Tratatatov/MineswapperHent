using System;

namespace HentaiGame
{
    public class PlayerMVC
    {

        private readonly CharacterView _characterView;
        private readonly PlayerStatsData _playerStatsData;
        private readonly CharacterTextReferences _characterTextReferences;


        public PlayerMVC(CharacterTextReferences characterTextReferences, PlayerStatsData playerStatsData,
            CharacterView characterView)
        {
            _characterTextReferences = characterTextReferences;
            _playerStatsData = playerStatsData;
            _characterView = characterView;
        }

        
        public void Initialize(int flagsCount)
        {
            
            _playerStatsData.SetStartValues();
            _playerStatsData.SetFlagsCount(flagsCount);
            _characterView.SetStartView();
            UpdateView();
        }

        private void UpdateView()
        {
            _characterTextReferences.SetText(_characterTextReferences.HpText, "HP", _playerStatsData.Hp);
            _characterTextReferences.SetText(_characterTextReferences.FlagsText, "Flags", _playerStatsData.Flags);
            _characterTextReferences.SetText(_characterTextReferences.LevelText, "Level", _playerStatsData.Level);
            _characterTextReferences.SetText(_characterTextReferences.CoinsText, "Coins", _playerStatsData.Money);
            _characterTextReferences.SetText(_characterTextReferences.TurnsText, "Turns", _playerStatsData.Turns);
        }

        public void AddCoins(int count)
        {
            _playerStatsData.IncreaseMoney(count);
            _characterTextReferences.SetText(_characterTextReferences.CoinsText, "Coins", _playerStatsData.Money);
        }
        
        public void AddTurns(int count)
        {
            _playerStatsData.IncreaseTurns(count);
            _characterTextReferences.SetText(_characterTextReferences.TurnsText, "Turns", _playerStatsData.Turns);
        }
        
        public void AddLevel(int count)
        {
            _playerStatsData.IncreaseLevel(count);
            _characterTextReferences.SetText(_characterTextReferences.LevelText, "Level", _playerStatsData.Level);
        }
        
        public void AddFlags(int count)
        {
            _playerStatsData.IncreaseFlags(count);
            _characterTextReferences.SetText(_characterTextReferences.FlagsText, "Flags", _playerStatsData.Flags);
        }
        
        public void DecreaseCoins(int count)
        {
            _playerStatsData.DecreaseMoney(count);
            _characterTextReferences.SetText(_characterTextReferences.CoinsText, "Coins", _playerStatsData.Money);
        }

        public void DecreaseTurns(int count)
        {
            _playerStatsData.DecreaseTurns(count);

            if (_playerStatsData.Turns <= 0)
            {
                GameEvents.OnPlayerTurnsOver?.Invoke();
            }
            
            _characterTextReferences.SetText(_characterTextReferences.TurnsText, "Turns", _playerStatsData.Turns);
        }
        
        public void DecreaseHp(int count)
        {
            _playerStatsData.DecreaseHp(count);
            _characterView.PlayDamageEffect(_playerStatsData.Hp);
            _characterTextReferences.SetText(_characterTextReferences.HpText, "HP", _playerStatsData.Hp);
        }
        
        public void DecreaseFlags(int count)
        {
            _playerStatsData.DecreaseFlags(count);
            _characterTextReferences.SetText(_characterTextReferences.FlagsText, "Flags", _playerStatsData.Flags);
        }
        
        public void SetFlagsCount(int count)
        {
            _playerStatsData.SetFlagsCount(count);
            _characterTextReferences.SetText(_characterTextReferences.FlagsText, "Flags", _playerStatsData.Flags);
        }

        public void SetMoneyCount(int count)
        {
            _playerStatsData.SetMoneyCount(count);
            _characterTextReferences.SetText(_characterTextReferences.CoinsText, "Coins", _playerStatsData.Money);
        }
        
        public void SetTurnsCount(int count)
        {
            _playerStatsData.SetTurnsCount(count);
            _characterTextReferences.SetText(_characterTextReferences.TurnsText, "Turns", _playerStatsData.Turns);
        }
        
        public void SetHpCount(int count)
        {
            _playerStatsData.SetHpCount(count);
            _characterTextReferences.SetText(_characterTextReferences.HpText, "HP", _playerStatsData.Hp);
        }
        
    }
}