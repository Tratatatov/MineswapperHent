using System;
using TMPro;
using UnityEngine;
namespace HentaiGame
{
    public class LevelInstaller : MonoBehaviour
    {
        [SerializeField] private LevelConfig _levelConfig;
        //[SerializeField] prviate Image
    }

    //[Serializable]
    //public class CharacterView
    //{
    //    [SerializeField] private Image _base;
    //    [SerializeField] private Image _costume;
    //    [SerializeField] private Image _bruses;
    //    [SerializeField] private Image _face;
    //}

    [Serializable]
    public class StatisticsView
    {
        [SerializeField] private TextMeshProUGUI _hpText;
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _flagsText;
    }

    public class CharacterPlacer
    {
        private CharacterIcon _characterIcon;
        private GameManager _gameManager;
        public void PlaceCharacterIconOnTile()
        {

        }
    }
}
