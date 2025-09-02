using UnityEngine;

namespace HentaiGame
{
    [CreateAssetMenu(fileName = "Настройки доски", menuName = "Настройки/Доска")]
    public class BoardConfig : ScriptableObject
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private int _numMines;

        public int Width => _width;
        public int Height => _height;
        public int NumMines => _numMines;
    }
}