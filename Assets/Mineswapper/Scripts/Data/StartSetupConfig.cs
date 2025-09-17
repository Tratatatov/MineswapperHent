using UnityEngine;
using UnityEngine.Serialization;

namespace HentaiGame
{
    [CreateAssetMenu(fileName = "Настройки начальных бонусов", menuName = "Настройки/Настройки начальных бонусов")]
    public class StartSetupConfig : ScriptableObject
    {
        public int StartGold;
        public int StartHp;
        public int StartTurns;
    }
}