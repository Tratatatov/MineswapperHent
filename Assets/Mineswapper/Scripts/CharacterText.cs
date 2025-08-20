using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]

public class CharacterText
{

    [Header("Текст")]
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _flagsText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _coinsText;

    #region Properties
    public TextMeshProUGUI FlagsText { get => _flagsText; }
    public TextMeshProUGUI LevelText { get => _levelText; }
    public TextMeshProUGUI CoinsText { get => _coinsText; }
    public TextMeshProUGUI HpText { get => _hpText; }
    #endregion

    public void SetText(TextMeshProUGUI text, string previewText, int value)
    {
        text.text = $"{previewText}: {value.ToString()}";
    }

    public void SetImage(Image imageType, Sprite sprite)
    {
    }


}

