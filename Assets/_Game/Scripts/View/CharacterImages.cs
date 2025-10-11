using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HentaiGame
{
    public class CharacterImages
    {
        private Face _face;
        private Bruses _bruses;
        private Outfit _outfit;
        private float _animationSpeed;
        private MonoBehaviour _coroutineStarter;

        private Coroutine _damageEffectCoroutine;

        
        public CharacterImages(CharacterImagesReferences characterImagesReferences,
            CharacterSpritesConfig characterSpritesConfig, float animationSpeed,
            MonoBehaviour coroutineStarter)
        {
            _outfit = new Outfit(characterSpritesConfig, characterImagesReferences.OutfitImage);
            _face = new Face(characterSpritesConfig, characterImagesReferences.FaceImage);
            _bruses = new Bruses(characterSpritesConfig, characterImagesReferences.BrusesImage);
            _animationSpeed = animationSpeed;
            _coroutineStarter = coroutineStarter;
        }

        public void SetStartView()
        {
            _outfit.SetNewOutfit();
            _face.SetNormalFace();
            _bruses.SetNoBruses();
        }

        public void PlayDamageEffect(int currentHp)
        {
            _damageEffectCoroutine = _coroutineStarter.StartCoroutine(PlayDamageCoroutine(currentHp));

            if (currentHp <= 2)
                _outfit.SetNudeBody();
            else if (currentHp <= 4)
                _outfit.SetStrongDestroy();
            else if (currentHp <= 6)
                _outfit.SetMiddleDestroy();
            else if (currentHp <= 8) _outfit.SetLightDestroy();
        }

        private IEnumerator PlayDamageCoroutine(int currentHp)
        {
            if (currentHp <= 4)
                _face.SetHornyFace();

            else
                _face.SetAngryFace();

            yield return new WaitForSeconds(_animationSpeed);

            _face.SetNormalFace();
        }
    }


    public class Outfit
    {
        private Image _outfitImage;
        private Sprite _newOutfit;
        private Sprite _lightDestroy;
        private Sprite _middleDestroy;
        private Sprite _strongDestroy;

        public Outfit(CharacterSpritesConfig characterSpritesConfig,
            Image outfitImage)
        {
            _outfitImage = outfitImage;
            _newOutfit = characterSpritesConfig.NewOutfitSprite;
            _lightDestroy = characterSpritesConfig.LightDestroyOutfitSprite;
            _middleDestroy = characterSpritesConfig.MiddleDestroyOutfitSprite;
            _strongDestroy = characterSpritesConfig.StrongDestroyOutfitSprite;
        }

        public void SetNewOutfit()
        {
            _outfitImage.sprite = _newOutfit;
        }

        public void SetLightDestroy()
        {
            _outfitImage.sprite = _lightDestroy;
        }

        public void SetMiddleDestroy()
        {
            _outfitImage.sprite = _middleDestroy;
        }

        public void SetStrongDestroy()
        {
            _outfitImage.sprite = _strongDestroy;
        }

        public void SetNudeBody()
        {
            _outfitImage.enabled = false;
        }
    }

    public class Face
    {
        private Image _faceImage;
        private Sprite _hornyFace;
        private Sprite _normalFace;
        private Sprite _angryFace;

        public Face(CharacterSpritesConfig characterSpritesConfig, Image faceImage)
        {
            _faceImage = faceImage;
            _hornyFace = characterSpritesConfig.HornyFaceSprite;
            _normalFace = characterSpritesConfig.NormalFaceSprite;
            _angryFace = characterSpritesConfig.AngryFaceSprite;
        }

        public void SetAngryFace()
        {
            _faceImage.sprite = _angryFace;
        }

        public void SetHornyFace()
        {
            _faceImage.sprite = _hornyFace;
        }

        public void SetNormalFace()
        {
            _faceImage.sprite = _normalFace;
        }
    }


    public class Bruses
    {
        private Image _brusesImage;
        private Sprite _smallBruses;
        private Sprite _middleBruses;

        public Bruses(CharacterSpritesConfig characterSpritesConfig, Image brusesImage)
        {
            _brusesImage = brusesImage;
            _smallBruses = characterSpritesConfig.SmallBrusesSprite;
            _middleBruses = characterSpritesConfig.MiddleDestroyOutfitSprite;
        }

        public void SetNoBruses()
        {
            _brusesImage.sprite = null;
        }

        public void SetSmallBruses()
        {
            _brusesImage.sprite = _smallBruses;
        }

        public void SetMiddleBruses()
        {
            _brusesImage.sprite = _middleBruses;
        }
    }
}