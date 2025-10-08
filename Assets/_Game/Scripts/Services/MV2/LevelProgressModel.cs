public class LevelProgressModel
{
    public LevelProgressModel(int turns, int flags)
    {
        Turns = turns;
        Flags = flags;
    }

    public int Flags { get; private set; }

    public int Turns { get; private set; }

    public void IncreaseFlags()
    {
        Flags++;
    }

    public bool TryDecreaseFlags()
    {
        if (Flags - 1 < 0)
            return false;
        Flags--;
        return true;
    }

    public void IncreaseTurns()
    {
        Turns++;
    }

    public void SetTurns(int turns)
    {
        Turns = turns;
    }


    public bool TryDecreaseTurns()
    {
        if (Turns - 1 < 0)
            return false;
        Turns--;
        return true;
    }
}