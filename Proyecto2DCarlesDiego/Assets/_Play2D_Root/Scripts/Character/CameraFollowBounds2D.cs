using UnityEngine;

public class CameraFollowBounds2D : MonoBehaviour
{
    public Transform target;
    public BoxCollider2D bounds;
    public float smoothSpeed = 5f;

    float minX, maxX, minY, maxY;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        Bounds b = bounds.bounds;

        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        minX = b.min.x + camWidth;
        maxX = b.max.x - camWidth;
        minY = b.min.y + camHeight;
        maxY = b.max.y - camHeight;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
        );

        Vector3 smooth = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);

        float x = Mathf.Clamp(smooth.x, minX, maxX);
        float y = Mathf.Clamp(smooth.y, minY, maxY);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
