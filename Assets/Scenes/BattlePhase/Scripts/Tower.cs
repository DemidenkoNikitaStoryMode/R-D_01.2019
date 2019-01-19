using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : BattleUnit
{
    public static Tower Instance { get; private set; }

    public int MaxHealth { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MaxHealth = 50;
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
