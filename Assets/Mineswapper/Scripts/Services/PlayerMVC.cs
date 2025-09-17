namespace HentaiGame
{
    public class PlayerMVC
    {
        private readonly CharacterTextReferences _characterTextReferences;
        private readonly CharacterView _characterView;
        private readonly PlayerStatsData _playerStatsData;


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
            _playerStatsData.SetFlagsCount(value: flagsCount);
            _characterView.SetStartView();
            UpdateView();
        }

        private void UpdateView()
        {
            _characterTextReferences.SetText(text: _characterTextReferences.HpText, "HP", value: _playerStatsData.Hp);
            _characterTextReferences.SetText(text: _characterTextReferences.FlagsText, "Flags",
                value: _playerStatsData.Flags);
            _characterTextReferences.SetText(text: _characterTextReferences.LevelText, "Level",
                value: _playerStatsData.Level);
            _characterTextReferences.SetText(text: _characterTextReferences.CoinsText, "Coins",
                value: _playerStatsData.Money);
            _characterTextReferences.SetText(text: _characterTextReferences.TurnsText, "Turns",
                value: _playerStatsData.Turns);
        }

        public void AddCoins(int count)
        {
            _playerStatsData.IncreaseMoney(count: count);
            _characterTextReferences.SetText(text: _characterTextReferences.CoinsText, "Coins",
                value: _playerStatsData.Money);
        }

        public void AddTurns(int count)
        {
            _playerStatsData.IncreaseTurns(count: count);
            _characterTextReferences.SetText(text: _characterTextReferences.TurnsText, "Turns",
                value: _playerStatsData.Turns);
        }

        public void AddLevel(int count)
        {
            _playerStatsData.IncreaseLevel(count: count);
            _characterTextReferences.SetText(text: _characterTextReferences.LevelText, "Level",
                value: _playerStatsData.Level);
        }

        public void AddFlags(int count)
        {
            _playerStatsData.IncreaseFlags(count: count);
            _characterTextReferences.SetText(text: _characterTextReferences.FlagsText, "Flags",
                value: _playerStatsData.Flags);
        }

        public void DecreaseCoins(int count)
        {
            _playerStatsData.DecreaseMoney(count: count);
            _characterTextReferences.SetText(text: _characterTextReferences.CoinsText, "Coins",
                value: _playerStatsData.Money);
        }

        public void DecreaseTurns()
        {
            _playerStatsData.DecreaseTurns(1);

            if (_playerStatsData.Turns <= 0) ChangeSceneService.GoToNextLevel();

            _characterTextReferences.SetText(text: _characterTextReferences.TurnsText, "Turns",
                value: _playerStatsData.Turns);
        }

        public void DecreaseHp(int count)
        {
            _playerStatsData.DecreaseHp(count: count);
            _characterView.PlayDamageEffect(currentHp: _playerStatsData.Hp);
            _characterTextReferences.SetText(text: _characterTextReferences.HpText, "HP", value: _playerStatsData.Hp);
            if (_playerStatsData.Hp <= 0) ServiceLocator.Get<GameOverService>().GameOver();
        }

        public void DecreaseFlags(int count)
        {
            _playerStatsData.DecreaseFlags(count: count);
            _characterTextReferences.SetText(text: _characterTextReferences.FlagsText, "Flags",
                value: _playerStatsData.Flags);
        }

        public void SetFlagsCount(int count)
        {
            _playerStatsData.SetFlagsCount(value: count);
            _characterTextReferences.SetText(text: _characterTextReferences.FlagsText, "Flags",
                value: _playerStatsData.Flags);
        }

        public void SetMoneyCount(int count)
        {
            _playerStatsData.SetMoneyCount(count: count);
            _characterTextReferences.SetText(text: _characterTextReferences.CoinsText, "Coins",
                value: _playerStatsData.Money);
        }

        public void SetTurnsCount(int count)
        {
            _playerStatsData.SetTurnsCount(count: count);
            _characterTextReferences.SetText(text: _characterTextReferences.TurnsText, "Turns",
                value: _playerStatsData.Turns);
        }

        public void SetHpCount(int count)
        {
            _playerStatsData.SetHpCount(count: count);
            _characterTextReferences.SetText(text: _characterTextReferences.HpText, "HP", value: _playerStatsData.Hp);
        }
    }
}