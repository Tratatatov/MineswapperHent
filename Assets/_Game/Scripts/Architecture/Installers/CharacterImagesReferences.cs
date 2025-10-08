using UnityEngine;
using UnityEngine.UI;

namespace HentaiGame
{
    public class CharacterImagesReferences : MonoBehaviour
    {
        public Image BrusesImage => _brusesImage;

        public Image OutfitImage => _outfitImage;

        public Image FaceImage => _faceImage;

        [SerializeField] private Image _brusesImage;
        [SerializeField] private Image _outfitImage;
        [SerializeField] private Image _faceImage;
    }
}