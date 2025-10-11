using UnityEngine;

namespace HentaiGame
{
    [CreateAssetMenu(fileName = "Настройки Анимации", menuName = "Настройки/Скорость анимаций")]
    public class AnimationSpeedConfig : ScriptableObject
    {
        public float FaceChangeSpeed;
        public float CameraShakeIntesity;
    }
}