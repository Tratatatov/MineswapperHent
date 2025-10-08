using TMPro;
using UnityEngine;

public class GlobalProgressView : MonoBehaviour
{
    [SerializeField] private GlobalProgressModelView _modelView;

    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _maxHpText;
    [SerializeField] private TextMeshProUGUI _maxTurnsText;

    private void OnEnable()
    {
        SubscribeToNotifire();
    }

    private void OnDisable()
    {
        UnsubscribeFromNotifire();
    }

    private void SubscribeToNotifire()
    {
        _modelView.OnCoinsUpdated += UpdateCoinsText;
        _modelView.OnMaxHpUpdated += UpdateHpText;
        _modelView.OnMaxTurnsUpdated += UpdateTurnsText;
    }

    private void UnsubscribeFromNotifire()
    {
        _modelView.OnCoinsUpdated -= UpdateCoinsText;
        _modelView.OnMaxHpUpdated -= UpdateHpText;
        _modelView.OnMaxTurnsUpdated -= UpdateTurnsText;
    }

    private void UpdateCoinsText(int count)
    {
        _coinsText.text = $"Coins: {count}";
    }

    private void UpdateTurnsText(int count)
    {
        _coinsText.text = $"MaxTurns: {count}";
    }

    private void UpdateHpText(int count)
    {
        _coinsText.text = $"MaxHp: {count}";
    }
}
