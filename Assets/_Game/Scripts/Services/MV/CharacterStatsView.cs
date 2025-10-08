using System;
using TMPro;
using UnityEngine;

namespace Test
{
    public class CharacterStatsView : MonoBehaviour
    {
        private RunProgressModel _model;
        [SerializeField] private TextMeshProUGUI _hpText;
        [SerializeField] private TextMeshProUGUI _levelText;
        
        public void SetHpText(int count)
        {
            _hpText.text = $"Hp: {count}";
        }

        public void SetLevelText(int count)
        {
            _levelText.text = $"Level: {count}";
        }
    }
}