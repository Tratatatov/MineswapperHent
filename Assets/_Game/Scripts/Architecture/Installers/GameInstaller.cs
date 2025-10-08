using UnityEngine;

namespace HentaiGame
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private StartSetupConfig _startSetupConfig;
        [SerializeField] private SoundManager _soundManager;
        [SerializeField] private PlayerDefaultStatsConfig _playerDefaultStatsConfig;

        public PlayerDefaultStatsConfig PlayerDefaultStatsConfig => _playerDefaultStatsConfig;

        public SoundManager SoundManager => _soundManager;

        public StartSetupConfig SetupConfig => _startSetupConfig;
    }
}