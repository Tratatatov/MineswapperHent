using System.Collections.Generic;
using UnityEngine;
namespace HentaiGame
{
    [CreateAssetMenu(fileName = "NewCharacterSettings", menuName = "CharacterCostumeSettings/NewCharacterSettings")]
    public class CostumeSettings : ScriptableObject
    {
        public List<Sprite> OutfitSprites;
        public List<Sprite> ScarsSprites;
        public List<Sprite> faceSprites;
        public Sprite BodyBaseSprite;

        public Sprite DefeatScene;
        public Sprite WinScene;
    }
}