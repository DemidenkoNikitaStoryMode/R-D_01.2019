using UnityEngine;

public class Enemy : BattleUnit
{

    public int MaxHealth = 25;

    private void Start()
    {
        Health = MaxHealth;
    }

    public override void DealDamage(BattleUnit target)
    {
        base.DealDamage(target);
        gameObject.SetActive(false);
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }
}
