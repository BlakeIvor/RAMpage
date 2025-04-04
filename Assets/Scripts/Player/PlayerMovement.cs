using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //THIS IS THE PLAYER INSTANCE
    public static PlayerMovement instance;

    GameManager gameManager;
    public Rigidbody2D rb;
    [SerializeField] float forwardForce, backwardForce, forwardVerticalY, backwardVerticalY;
    float verticalY;
    private Vector2 forwardForceVec, backwardForceVec;
    public float prevVelocityX = 0; // USED FOR GETTING THE SPEED RIGHT BEFORE A COLLISION
    private float timeCalculatingBeforeCollision = 1;
    private float timer = 0f;
    private float startingPositionY;
    [SerializeField] float moveUpDownDistance = 0.3f;

    private void Awake()
    {
        if(!instance) instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();

        forwardForceVec = new Vector2(forwardForce, 0);
        backwardForceVec = new Vector2(-backwardForce, 0);
        startingPositionY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.getAllowInput())
        {
            if (Input.GetAxis("Horizontal") < 0)
            { // Reverse 
                rb.AddForce(backwardForceVec);
            }
            else
            {
                rb.AddForce(forwardForceVec); // Accelerate
            }
            rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocity.x, gameManager.minMovementSpeed, gameManager.maxMovementSpeed), rb.linearVelocity.y); //Max/min

            // Can't move up/down as fast is backing up
            if (rb.linearVelocity.y > 1) verticalY = forwardVerticalY; else verticalY = backwardVerticalY;

            // Move up/down
            if (Input.GetAxis("Vertical") < 0) transform.Translate(0, -verticalY * Time.deltaTime, 0);
            else if (Input.GetAxis("Vertical") > 0) transform.Translate(0, verticalY * Time.deltaTime, 0);

            //up/down velocity 0
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);

            //clamp up/down
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, startingPositionY - moveUpDownDistance, startingPositionY + moveUpDownDistance));


            timer += Time.deltaTime;
            if (timer >= timeCalculatingBeforeCollision)
            {
                timer = 0f; // Reset timer
                prevVelocityX = rb.linearVelocity.x;
            }
        }
    }

    
}
