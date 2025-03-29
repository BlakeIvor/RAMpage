using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float forward, backward;
    private Vector2 forwardVec, backwardVec;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        forwardVec = new Vector2(forward, 0);
        backwardVec = new Vector2(backward, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) rb.AddForce(backwardVec); else rb.AddForce(forwardVec);
        
    }
}
