using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float MinSpeed = 1.25f;
    public float MaxSpeed = 1.75f;
    public Rigidbody2D Rb;
    public Enemy Enemy;

    private bool shouldMove = true;
    private float speed;

    private void Start()
    {
        speed = Random.Range(MinSpeed, MaxSpeed);
        transform.up = Tower.Instance.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        if (!shouldMove)
        {
            Rb.velocity = Vector2.zero;
            return;
        }
        Rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Tower"))
        {
            var tower = coll.GetComponent<Tower>();
            shouldMove = false;
            Enemy.DealDamage(tower);
        }
    }
}
