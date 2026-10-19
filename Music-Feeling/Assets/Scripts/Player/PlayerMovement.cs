using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundlayer;
    bool isRunning = false;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

   
    async Task Update()
    {
        float moveinput = Input.GetAxis("Horizontal");
        anim.SetBool("isRunning", moveinput != 0);
        rb.linearVelocity = new Vector2(moveinput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("Jump");
            await Task.Delay(200);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundlayer);
        Debug.Log("Is Grounded: " + isGrounded); 
    }
}
