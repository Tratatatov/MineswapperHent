namespace HentaiGame
{
    public class HealthSystem
    {
        private int _maxHp;

        public int CurrentHp { get; private set; }

        public void IncreaseHp(int count)
        {
            CurrentHp += count;
            if (CurrentHp > _maxHp) CurrentHp = _maxHp;
        }

        public void DecreaseHp(int count)
        {
            CurrentHp -= count;
            if (CurrentHp < 0) CurrentHp = 0;
        }

        public void Init(int maxHp)
        {
            _maxHp = maxHp;
        }
    }
}