public class MoneyService
{
    private int _currentMoney;

    public MoneyService(int currentMoney)
    {
        _currentMoney = currentMoney;
    }

    public int CurrentMoney => _currentMoney;

    public void AddMoney(int amount)
    {
        _currentMoney += amount;
    }

    public void RemoveMoney(int amount)
    {
        _currentMoney-= amount;
    }
}