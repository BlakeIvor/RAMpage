using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MagicBallBehavior : MonoBehaviour
{
    public float damage = 40;
    [SerializeField] private float rotationSpeed;
    Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = PlayerMovement.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
