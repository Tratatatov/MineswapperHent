using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewCharacterSettings", menuName = "CharacterCostumeSettings/NewCharacterSettings")]
public class CharacterSettings : ScriptableObject
{
    public Sprite BodyBase; 
    public List<Sprite> ScarsBody;
    public List<Sprite> FaceSprite;
}
