using Assets.Scripts.Model;

public class GameModel
{
    public int Money { get; set; }

    public TowerStats TowerStats;
    public PlayerStats PlayerStats;

    public static GameModel DefaultGameModel()
    {
        return new GameModel()
        {
            Money = 100,
            PlayerStats = PlayerStats.CreateDefaultPlayerStats(),
            TowerStats = TowerStats.DefaultTowerStats()
        };
    }
}
