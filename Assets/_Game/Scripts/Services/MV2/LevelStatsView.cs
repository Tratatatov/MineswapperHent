using TMPro;
using UnityEngine;

namespace HentaiGame.MV2
{
    public class LevelStatsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _hpText;
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _flagsText;
        [SerializeField] private TextMeshProUGUI _turnsText;

        public void SetTurns(int count)
        {
            _turnsText.text = $"Turns: {count}";
        }

        public void SetCoins(int amount)
        {
            _coinsText.text = $"Coins: {amount}";
        }

        public void SetFlags(int count)
        {
            _flagsText.text = $"Flags: {count}";
        }

        public void SetLevelText(int count)
        {
            _levelText.text = $"Level: {count}";
        }

        public void SetHpText(int hp)
        {
            _hpText.text = $"Hp: {hp}";
        }
    }
}