using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform player;

    public void Move(float speed)
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0) x *= speed;
        if (y != 0) y *= speed;

        Vector3 newPositions = player.position + new Vector3(x, y, 0f);
        player.position = Vector3.Lerp(player.position, newPositions, 0.1f);
    }

    public void MoveTo(Vector3 newPos)
    {
        player.position = newPos;
    }
}
