namespace HentaiGame
{
    public class SaveManager
    {
        private PlayerData _playerData;
        private PlayerDataPersistance _playerDataPersistance;

        public SaveManager(PlayerDataPersistance playerDataPersistance, PlayerData playerData)
        {
            _playerDataPersistance = playerDataPersistance;
            _playerData = playerData;
        }

        public void SaveAll()
        {
            _playerData.Save(dataName: DataName.Coins, value: _playerDataPersistance.Coins);
            _playerData.Save(dataName: DataName.MaxHP, value: _playerDataPersistance.MaxHP);
            _playerData.Save(dataName: DataName.Level, value: _playerDataPersistance.Level);
            _playerData.Save(dataName: DataName.HP, value: _playerDataPersistance.HP);
            _playerData.Save(dataName: DataName.MaxTurns, value: _playerDataPersistance.MaxTurns);
            _playerData.Save(dataName: DataName.HPRegen, value: _playerDataPersistance.HPRegen);
        }


        public void LoadAll()
        {
            _playerDataPersistance.Coins = _playerData.Load(dataName: DataName.Coins);
            _playerDataPersistance.MaxHP = _playerData.Load(dataName: DataName.MaxHP);
            _playerDataPersistance.HP = _playerData.Load(dataName: DataName.HP);
            _playerDataPersistance.MaxTurns = _playerData.Load(dataName: DataName.MaxTurns);
            _playerDataPersistance.HPRegen = _playerData.Load(dataName: DataName.HPRegen);
            _playerDataPersistance.Level = _playerData.Load(dataName: DataName.Level);
        }

        public void Reset()
        {
            _playerData.Reset();
        }
    }
}