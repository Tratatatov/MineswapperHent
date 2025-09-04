using UnityEngine;

namespace Mineswapper
{
    public class GameSaveService
    {
        private GameData _gameData;
        private const string PlayerSave = "PlayerSave";

        public void SaveGame()
        {
            string gameData = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(PlayerSave, gameData);
        }
    }

    public class GameData
    {
        public int Level => _level;

        public int Money => _money;

        public int Lives => _lives;

        private int _level;
        private int _money;
        private int _lives;

        public void IncreaseLevel()
        {
            _level++;
        }

        public void AddMoney(int count)
        {

        }

        public void DecreaseMoney(int count)
        {
        }
    }
}