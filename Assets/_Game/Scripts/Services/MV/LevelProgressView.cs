using TMPro;
using UnityEngine;

public class LevelProgressView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _turnsText;

    [SerializeField] private TextMeshProUGUI _flagsText;

    public void SetTurnsText(int count)
    {
        _turnsText.text = $"Turns: {count}";
    }

    public void SetFlagsText(int count)
    {
        _turnsText.text = $"Flags: {count}";
    }
}