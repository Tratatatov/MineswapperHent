using UnityEngine;

public class LevelProgressController : MonoBehaviour
{
    [SerializeField] private LevelProgressView _view;
    private LevelProgressModel _model;

    public void SetTurns(int count)
    {
        _model.SetTurns(turns: count);
        UpdateTurnsText();
    }

    public void IncreaseFlags()
    {
        _model.IncreaseFlags();
        UpdateFlagsText();
    }

    public bool TryDecreaseFlags()
    {
        if (_model.TryDecreaseFlags()) UpdateFlagsText();
        return _model.TryDecreaseFlags();
    }

    public void IncreaseTurns()
    {
        _model.IncreaseTurns();
        UpdateTurnsText();
    }

    public bool TryDecreaseTurns()
    {
        if (_model.TryDecreaseTurns())
            UpdateTurnsText();
        return _model.TryDecreaseTurns();
    }

    private void UpdateTurnsText()
    {
        _view.SetTurnsText(count: _model.Turns);
    }

    private void UpdateFlagsText()
    {
        _view.SetFlagsText(count: _model.Flags);
    }
}