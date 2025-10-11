using UnityEngine;

namespace HentaiGame
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private SoundManager _soundManager;
        [SerializeField] private PlayerDefaultStatsConfig _playerDefaultStatsConfig;

        public PlayerDefaultStatsConfig PlayerDefaultStatsConfig => _playerDefaultStatsConfig;

        public SoundManager SoundManager => _soundManager;

    }
}