using UnityEngine;

public abstract class BattleUnit : MonoBehaviour
{

    public int MinDamage = 5;
    public int MaxDamage = 10;

    public int Health { get; protected set; }

    public bool IsAlive
    {
        get { return Health > 0; }
    }

    public virtual void DealDamage(BattleUnit target)
    {
        if (!IsAlive)
        {
            return;
        }
        target.TakeDamage(GetRandomDamage());
    }

    public virtual int GetRandomDamage()
    {
        return Random.Range(MinDamage, MaxDamage);
    }

    public virtual void TakeDamage(int damage)
    {
        if (!IsAlive)
        {
            return;
        }
        Health -= damage;
        if (!IsAlive)
        {
            Die();
        }
    }

    public abstract void Die();
}
