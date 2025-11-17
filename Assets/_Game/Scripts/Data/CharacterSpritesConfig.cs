 using UnityEngine;

namespace HentaiGame
{
    [CreateAssetMenu(fileName = "Спрайты Персонажа", menuName = "Настройки/Спрайты Персонажа")]
    public class CharacterSpritesConfig : ScriptableObject
    {
        public Sprite BodyBaseSprite;
        [Header("Одежда")] public Sprite NewOutfitSprite;
        public Sprite LightDestroyOutfitSprite;
        public Sprite MiddleDestroyOutfitSprite;
        public Sprite StrongDestroyOutfitSprite;
        [Header("Лицо")] public Sprite NormalFaceSprite;
        public Sprite AngryFaceSprite;
        public Sprite HornyFaceSprite;
        [Header("Шрамы")] public Sprite SmallBrusesSprite;
        [Header("Мини Иконка")] public Sprite SmallIconSprite;

        public Sprite DefeatScene;
        public Sprite WinScene;
    }
}