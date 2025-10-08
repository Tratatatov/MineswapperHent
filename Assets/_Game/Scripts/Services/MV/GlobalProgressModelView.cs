using System;

public class GlobalProgressModelView
{
    private readonly PlayerDefaultStatsConfig _defaultStatsConfig;
    private GlobalProgressModel _model;
    public Action<int> OnCoinsUpdated;
    public Action<int> OnMaxHpUpdated;
    public Action<int> OnMaxTurnsUpdated;

    public GlobalProgressModelView(PlayerDefaultStatsConfig defaultStatsConfig)
    {
        _defaultStatsConfig = defaultStatsConfig;
    }

    public void IncreaseMaxTurns()
    {
        _model.IncreaseMaxTurns();
        OnMaxTurnsUpdated?.Invoke(obj: _model.MaxTurns);
    }

    public void IncreaseMaxHp()
    {
        _model.IncreaseMaxHp();
        OnMaxHpUpdated?.Invoke(obj: _model.MaxHp);
    }

    public void AddCoins(int amount)
    {
        _model.AddCoins(amount: amount);
        OnCoinsUpdated?.Invoke(obj: _model.Coins);
    }

    public bool TryDecreaseCoins(int amount)
    {
        // Вызываем метод Model один раз и сохраняем результат
        bool result = _model.TryDecreaseCoins(amount: amount);

        // Если успешно, уведомляем подписчиков (например, View)
        if (result) OnCoinsUpdated?.Invoke(obj: _model.Coins);

        // Возвращаем результат
        return result;
    }

    public void SaveProgress()
    {
        _model.Save();
    }

    public void LoadProgress()
    {
        _model.TryLoad(maxDefaultTurns: _defaultStatsConfig.MaxTurns,
            maxDefaultHp: _defaultStatsConfig.MaxHp);

        OnMaxHpUpdated?.Invoke(obj: _model.MaxHp);
        OnMaxTurnsUpdated?.Invoke(obj: _model.MaxTurns);
        OnCoinsUpdated?.Invoke(obj: _model.Coins);
    }

    public void ResetProgress()
    {
        _model.Reset();
    }
}