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
            _playerStatsData.SetFlagValue(flagsCount);
            _characterView.SetStartView();
            UpdateView();
        }

        private void UpdateView()
        {
            _characterTextReferences.SetText(_characterTextReferences.HpText, "HP", _playerStatsData.Hp);
            _characterTextReferences.SetText(_characterTextReferences.FlagsText, "Flags", _playerStatsData.Flags);
            _characterTextReferences.SetText(_characterTextReferences.LevelText, "Level", _playerStatsData.Level);
            _characterTextReferences.SetText(_characterTextReferences.CoinsText, "Coins", _playerStatsData.Coins);
        }

        public void TakeDamage(int count)
        {
            _playerStatsData.ChangeHp(-count);
            _characterView.PlayDamageEffect(_playerStatsData.Hp);
            _characterTextReferences.SetText(_characterTextReferences.HpText, "HP", _playerStatsData.Hp);
        }

        public void ChangeCoins(int count)
        {
            _playerStatsData.ChangeCoins(count);
            _characterTextReferences.SetText(_characterTextReferences.CoinsText, "Coins", _playerStatsData.Coins);
        }

        public void ChangeFlags(int count)
        {
            _playerStatsData.ChangeFlags(count);
            _characterTextReferences.SetText(_characterTextReferences.FlagsText, "Flags", _playerStatsData.Flags);
        }

        public void IncreaseLevel(int count)
        {
            _playerStatsData.IncreaseLevel(count);
            _characterTextReferences.SetText(_characterTextReferences.LevelText, "Level", _playerStatsData.Level);
        }
    }
}