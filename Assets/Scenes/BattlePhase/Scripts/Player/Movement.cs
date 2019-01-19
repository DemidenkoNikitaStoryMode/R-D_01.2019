using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform player;

    public void Move(float speed)
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)
        {
            var angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            player.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

            x *= speed;
            y *= speed;
        }

        Vector3 newPositions = player.position + new Vector3(x, y, 0f);
        player.position = Vector3.Lerp(player.position, newPositions, 0.1f);


    }

    public void MoveTo(Vector3 newPos)
    {
        player.position = newPos;
    }

    public Vector3 GetPlayerPosition()
    {
        return player.position;
    }
}
