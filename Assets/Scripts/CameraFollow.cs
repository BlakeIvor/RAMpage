using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] Transform target;
    [SerializeField] float lerpX = 0.1f, lerpY = 0.1f;
    [SerializeField] float positionZ = -10f;  // Keep the camera at a fixed Z distance, adjust as necessary
    [SerializeField] float offsetX = 0f, offsetY = 0f;
    [SerializeField] float minDistanceX = 2.5f;

    private float smoothSpeedX;
    private float smoothSpeedY;

    // Start is called once before the first execution of Update
    void Start()
    {
        transform.position = target.position + new Vector3(offsetX, transform.position.y, positionZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (target && GameManager.instance.getAllowInput())
        {
            Follow();
        }
    }

    void Follow()
    {
        float targetX = target.position.x + offsetX;
        float targetY = transform.position.y + offsetY;

        transform.position = new Vector3(
            targetX,
            targetY,
            positionZ
        );
    }
}
