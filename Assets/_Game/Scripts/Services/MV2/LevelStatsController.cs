using HentaiGame.MV2;

public class LevelStatsController
{
    private readonly GlobalProgressModel _globalProgressModel;
    private readonly LevelProgressModel _levelProgressModel;
    private readonly LevelStatsView _levelStatsView;
    private readonly RunProgressModel _runProgressModel;

    public LevelStatsController(LevelProgressModel levelProgressModel, RunProgressModel runProgressModel,
        GlobalProgressModel globalProgressModel, LevelStatsView levelStatsView)
    {
        _levelProgressModel = levelProgressModel;
        _runProgressModel = runProgressModel;
        _globalProgressModel = globalProgressModel;
        _levelStatsView = levelStatsView;
    }

    public void TryDecreaseTurns()
    {
        TryDecreaseTurns();
        _levelStatsView.SetTurns(count: _levelProgressModel.Turns);
    }

    public void SetTurns(int turns)
    {
        _levelProgressModel.SetTurns(turns: turns);
        _levelStatsView.SetTurns(count: turns);
    }

    public void AddCoins(int amount)
    {
        _globalProgressModel.AddCoins(amount: amount);
        _levelStatsView.SetCoins(amount: _globalProgressModel.Coins);
    }

    public void SetLevel(int level)
    {
        _runProgressModel.SetLevel(count: level);
        _levelStatsView.SetLevelText(count: level);
    }
}