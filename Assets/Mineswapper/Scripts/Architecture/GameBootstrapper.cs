using UnityEngine;

namespace HentaiGame
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private StartSetupConfig _startSetupConfig;

        public StartSetupConfig StartSetupConfig => _startSetupConfig;

        public void Initialize()
        {
            if (PlayerPrefs.HasKey("MaxHp"))
                PlayerProgeress.LoadProgress();
            
            else
                PlayerProgeress.SetStartValues(turns: _startSetupConfig.StartTurns, maxHp: _startSetupConfig.StartHp);
        }
    }
}