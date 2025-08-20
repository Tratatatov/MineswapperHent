using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Outfit _outfit;
    [SerializeField] private Face _face;
    [SerializeField] private Bruses _bruses;
    [SerializeField] private float _damageTime;

    private Coroutine _damageEffectCoroutine;

    public void Initialize()
    {

    }

    public void SetStartView()
    {
        _outfit.SetNewOutfit();
        _face.SetNormalFace();
        _bruses.SetNoBruses();
    }

    public void PlayDamageEffect(int currentHp)
    {
        _damageEffectCoroutine = StartCoroutine(PlayDamageCoroutine(currentHp));

        if (currentHp <= 2)
        {
            _outfit.SetNudeBody();
        }
        else if (currentHp <= 4)
        {
            _outfit.SetStrongDestroy();
        }
        else if (currentHp <= 6)
        {
            _outfit.SetMiddleDestroy();
        }
        else if (currentHp <= 8)
        {
            _outfit.SetLightDestroy();
        }
    }

    private IEnumerator PlayDamageCoroutine(int currentHp)
    {
        if (currentHp <= 4)
        {
            _face.SetHornyFace();
        }

        else
        {
            _face.SetAngryFace();
        }

        yield return new WaitForSeconds(_damageTime);

        _face.SetNormalFace();
    }
}

[Serializable]
public class Outfit
{
    [SerializeField] private Image _outfitImage;
    [SerializeField] private Sprite _newOutfit;
    [SerializeField] private Sprite _lightDestroy;
    [SerializeField] private Sprite _middleDestroy;
    [SerializeField] private Sprite _strongDestroy;

    public void SetNewOutfit() => _outfitImage.sprite = _newOutfit;
    public void SetLightDestroy() => _outfitImage.sprite = _lightDestroy;
    public void SetMiddleDestroy() => _outfitImage.sprite = _middleDestroy;
    public void SetStrongDestroy() => _outfitImage.sprite = _strongDestroy;
    public void SetNudeBody() => _outfitImage.enabled = false;
}

[Serializable]
public class Face
{
    [SerializeField] private Image _faceImage;
    [SerializeField] private Sprite _hornyFace;
    [SerializeField] private Sprite _normalFace;
    [SerializeField] private Sprite _angryFace;

    public void SetAngryFace() => _faceImage.sprite = _angryFace;
    public void SetHornyFace() => _faceImage.sprite = _hornyFace;
    public void SetNormalFace() => _faceImage.sprite = _normalFace;
}

[Serializable]
public class Bruses
{
    [SerializeField] private Image _brusesImage;
    [SerializeField] private Sprite _smallBruses;
    [SerializeField] private Sprite _middleBruses;

    public void SetNoBruses() => _brusesImage.sprite = null;
    public void SetSmallBruses() => _brusesImage.sprite = _smallBruses;
    public void SetMiddleBruses() => _brusesImage.sprite = _middleBruses;
}

