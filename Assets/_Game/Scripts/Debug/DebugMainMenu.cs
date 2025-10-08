using System;
using HentaiGame;
using UnityEngine;
using UnityEngine.UI;

public class DebugMainMenu : MonoBehaviour
{
    [SerializeField] private Button _resetButton;
    private void OnEnable()
    {
        _resetButton.onClick.AddListener(ResetSaves);
    }

    private void OnDisable()
    {
        _resetButton.onClick.RemoveAllListeners();
    }

    private void ResetSaves()
    {
    }
}
