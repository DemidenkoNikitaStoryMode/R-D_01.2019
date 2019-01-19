using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Camera camera;

    [Header("Settings")]
    [SerializeField] float cameraSpeed;
    [SerializeField] float zoneHeight;
    [SerializeField] float zoneWidth; 

    public void MoveCamera()
    {
        float x = 0f;
        float y = 0f;

        Vector2 viewPort = camera.ScreenToViewportPoint(Input.mousePosition);

        if (viewPort.x > 0.9f) x = 1f;
        if (viewPort.x < 0.1f) x = -1f;
        if (viewPort.y > 0.9f) y = 1f;
        if (viewPort.y < 0.1f) y = -1f;

        Vector3 newPositions = cameraTransform.position + new Vector3(x, y, 0f);
        newPositions.x = Mathf.Clamp(newPositions.x,-zoneWidth, zoneWidth);
        newPositions.y = Mathf.Clamp(newPositions.y, -zoneHeight, zoneHeight);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPositions, cameraSpeed);
    }

    public void MoveTo(Vector3 newPos)
    {
        cameraTransform.position = newPos;
    }
}
