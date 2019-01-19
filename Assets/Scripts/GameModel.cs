﻿using UnityEngine;

public class GameModel : MonoBehaviour
{
    public int MaxHealth { get; set; }

    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }

    // In seconds
    public float FireRate { get; set; }

    // In percents
    public float SlowFactor { get; set; }
}
