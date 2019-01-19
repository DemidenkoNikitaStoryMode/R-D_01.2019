using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MinDamage = 5;
    public int MaxDamage = 10;

    public void Attack(Tower tower)
    {
        var damage = Random.Range(MinDamage, MaxDamage);
        tower.TakeDamage(damage);
        gameObject.SetActive(false);
    }
}
