using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bile�enini al
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // E�ilmeyi �nle
    }

    void Update()
    {
        float moveDirection = Input.GetAxisRaw("Horizontal");

        bool isJumped = Input.GetKeyDown(KeyCode.W);

        bool isSpeaking = Input.GetKey(KeyCode.LeftShift);

        // Hareketi Rigidbody2D ile sa�la
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Z�plama (Sadece yerdeyken)
        if (isJumped && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Havada oldu�unu belirle
            animator.SetTrigger("Jump"); // Jump animasyonunu tetikle
        }

        animator.SetBool("isWalking", moveDirection != 0 && !isSpeaking);
        animator.SetBool("isSpeaking", isSpeaking);

        if (moveDirection != 0)
        {
            spriteRenderer.flipX = moveDirection < 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        }
    }
}
