using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundlayer; 

    private Rigidbody2D rb;
    private bool isGrounded; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

   
    void Update()
    {
        float moveinput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveinput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundlayer); 
    }
}
