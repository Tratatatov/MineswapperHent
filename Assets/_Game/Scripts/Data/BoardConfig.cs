using UnityEngine;

namespace HentaiGame
{
    [CreateAssetMenu(fileName = "Настройки доски", menuName = "Настройки/Доска")]
    public class BoardConfig : ScriptableObject
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private int _numMines;
        [SerializeField] private int _coinsCount;

        public int Width => _width;
        public int Height => _height;
        public int NumMines => _numMines;

        public int CoinsCount => _coinsCount;
    }
}