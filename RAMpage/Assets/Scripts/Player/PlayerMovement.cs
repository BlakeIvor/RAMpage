using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float forwardForce, backwardForce, forwardVerticalY, backwardVerticalY;
    float verticalY;
    [SerializeField] float maxReverse, maxForward;
    private Vector2 forwardForceVec, backwardForceVec;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        forwardForceVec = new Vector2(forwardForce, 0);
        backwardForceVec = new Vector2(-backwardForce, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Horizontal") < 0) { // Reverse 
            rb.AddForce(backwardForceVec);
        } else rb.AddForce(forwardForceVec); // Accelerate
        rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocity.x, maxReverse, maxForward), rb.linearVelocity.y); //Max/min

        // Can't move up/down as fast is backing up
        if (rb.linearVelocity.y > 1) verticalY = forwardVerticalY; else verticalY = backwardVerticalY;

        // Move up/down
        if (Input.GetAxis("Vertical") < 0) transform.Translate(0, -verticalY * Time.deltaTime, 0);
        else if (Input.GetAxis("Vertical") > 0) transform.Translate(0, verticalY * Time.deltaTime, 0);

    }
}
