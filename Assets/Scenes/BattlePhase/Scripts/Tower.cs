﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ModelLoader;
using UnityEngine;

public class Tower : BattleUnit
{
    public static Tower Instance { get; private set; }

    public int MaxHealth { get; private set; }
    public float FireRate { get; private set; }
    public float SlowFactor { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        var gameModel = new PlayerPrefsModelLoader().LoadGameModel() ?? GameModel.DefaultGameModel();

        MaxHealth = gameModel.TowerStats.MaxHealth;
        FireRate = gameModel.TowerStats.FireRate;
        MinDamage = gameModel.TowerStats.MinDamage;
        MaxDamage = gameModel.TowerStats.MaxDamage;
        SlowFactor = gameModel.TowerStats.SlowFactor;

        Health = MaxHealth;
    }

    public override void TakeDamage(int damage)
    {
        if (!IsAlive)
        {
            return;
        }
        base.TakeDamage(damage);
        Debug.Log("Ouch! " + damage + " damage; health = " + Health);
    }

    public override void Die()
    {
        Debug.LogError("TOWER DESTROYED");
        gameObject.SetActive(false);
    }
}
