using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Camera cam;

    [Header("Settings")]
    [SerializeField] float cameraSpeed;
    [SerializeField] float zoneHeight;
    [SerializeField] float zoneWidth;

    public void MoveCamera()
    {
        float x = 0f;
        float y = 0f;

        Vector2 viewPort = cam.ScreenToViewportPoint(Input.mousePosition);

        if (viewPort.x > 0.9f) x = 1f;
        if (viewPort.x < 0.1f) x = -1f;
        if (viewPort.y > 0.9f) y = 1f;
        if (viewPort.y < 0.1f) y = -1f;

        Vector3 newPositions = cameraTransform.position + new Vector3(x, y, 0f);
        newPositions = Clamp(newPositions);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPositions, cameraSpeed);
    }

    public void MoveTo(Vector3 newPos)
    {
        cameraTransform.position = Clamp(newPos);
    }

    private Vector3 Clamp(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, -zoneWidth, zoneWidth);
        pos.y = Mathf.Clamp(pos.y, -zoneHeight, zoneHeight);
        return pos;
    }

}
