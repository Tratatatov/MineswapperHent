using System;
using TMPro;
using UnityEngine;

namespace HentaiGame
{
    [Serializable]
    public class CharacterTextReferences
    {
        [SerializeField] private TextMeshProUGUI _hpText;
        [SerializeField] private TextMeshProUGUI _flagsText;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private TextMeshProUGUI _turnsText;

        public TextMeshProUGUI TurnsText => _turnsText;

        public void SetText(TextMeshProUGUI text, string previewText, int value)
        {
            text.text = $"{previewText}: {value.ToString()}";
        }

        #region Properties

        public TextMeshProUGUI FlagsText => _flagsText;
        public TextMeshProUGUI LevelText => _levelText;
        public TextMeshProUGUI CoinsText => _coinsText;
        public TextMeshProUGUI HpText => _hpText;

        #endregion
    }
}