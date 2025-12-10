using UnityEngine;
using Zenject;

namespace HentaiGame
{
    public class HealAbility : MonoBehaviour
    {
        public static HealAbility Instance;
        private CharacterOnBoard _characterOnBoard;
        private int _currentTurn;
        private HealingConfig _healingConfig;
        private int _turnsToHeal;

        private void Awake()
        {
            Instance = this;
            if (Instance != this) Destroy(obj: gameObject);
            Init();
            DontDestroyOnLoad(this);
        }

        [Inject]
        public void Construct(CharacterOnBoard characterOnBoard, HealingConfig healingConfig)
        {
            _characterOnBoard = characterOnBoard;
            _healingConfig = healingConfig;
        }

        private void Init()
        {
            _turnsToHeal = _healingConfig.TurnsToHeal;
            _currentTurn = _turnsToHeal;
        }

        public void TryToHeal(CharacterStatsView characterStatsView)
        {
            _currentTurn--;
            if (_currentTurn <= 0)
            {
                characterStatsView.InscreaseHp(1);
                _currentTurn = _turnsToHeal;
                _characterOnBoard.PlayHealEffect();
            }
        }
    }
}