﻿namespace Assets.Scripts.Model
{
    public class TowerStats
    {
        public int MaxHealth { get; set; }

        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        // In seconds
        public float FireRate { get; set; }

        // In percents
        public float SlowFactor { get; set; }

        // Default values
        public static TowerStats DefaultTowerStats()
        {
            return new TowerStats()
            {
                FireRate = 1f,
                MinDamage = 1,
                MaxDamage = 2,
                MaxHealth = 1,
                SlowFactor = 0f
            };
        }
    }
}