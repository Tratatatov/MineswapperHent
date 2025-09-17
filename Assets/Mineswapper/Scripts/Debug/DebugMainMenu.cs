using System;
using HentaiGame;
using UnityEngine;
using UnityEngine.UI;

public class DebugMainMenu : MonoBehaviour
{
    [SerializeField] private Button _resetButton;
    [SerializeField] private GameBootstrapper _gameBootstrapper;
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
        PlayerProgeress.ResetProgress(_gameBootstrapper.StartSetupConfig.StartTurns,_gameBootstrapper.StartSetupConfig.StartHp);
    }
}
