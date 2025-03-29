using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] Transform target;
    [SerializeField] float lerpX, lerpY;
    [SerializeField] float positionX, positionY, positionZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = target.position;
        positionX = target.position.x;
        positionY = target.position.y;
        Follow();

    }

    // Update is called once per frame
    void Update()
    {
        if(target && GameManager.instance.getAllowInput()) Follow();
    }

    void Follow()
    {
        positionX = Mathf.Lerp(transform.position.x, target.position.x, lerpX);
        positionY = Mathf.Lerp(transform.position.y, target.position.y, lerpY);
        transform.position = new Vector3(positionX, positionY, positionZ);
    }
}
