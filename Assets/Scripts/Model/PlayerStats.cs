namespace Assets.Scripts.Model
{
    public class PlayerStats
    {
        public float Speed { get; set; }
        // In seconds
        public float RespawnTime { get; set; }

        public static PlayerStats CreateDefaultPlayerStats()
        {
            return new PlayerStats()
            {
                Speed = 0.3f,
                RespawnTime = 10f
            };
        }
    }
}