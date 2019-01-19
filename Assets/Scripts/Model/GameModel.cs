public class GameModel
{
    public int Money { get; set; }

    public int MaxHealth { get; set; }

    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }

    // In seconds
    public float FireRate { get; set; }

    // In percents
    public float SlowFactor { get; set; }

    // Default values
    public static GameModel DefaultModel()
    {
        return new GameModel()
        {
            FireRate = 1f,
            MinDamage = 1,
            MaxDamage = 2,
            MaxHealth = 1,
            Money = 10000,
            SlowFactor = 0f
        };
    }
}
