using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float Speed = 1;
    public Rigidbody2D Rb;

    private bool shouldMove = true;

    private void Start()
    {
        transform.up = Tower.Instance.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        if (!shouldMove)
        {
            Rb.velocity = Vector2.zero;
            return;
        }
        Rb.velocity = transform.up * Speed;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Tower"))
        {
            shouldMove = false;

        }
    }
}
