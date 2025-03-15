using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform lantern;
    public Transform canbari;
    public Vector2 lanternOffset = new Vector2(0.5f, 0.0f);
    public Vector2 canbariOffset = new Vector2(0f, 0f);

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if (!gameObject.activeSelf) return; // Eðer karakter aktif deðilse hareket etme

        float moveDirection = Input.GetAxisRaw("Horizontal");
        bool isJumped = Input.GetKeyDown(KeyCode.W);
        bool isSpeaking = Input.GetKey(KeyCode.LeftShift);

        // Hareketi Rigidbody2D ile saðla
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Zýplama (Sadece yerdeyken)
        if (isJumped && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetTrigger("Jump");
        }

        animator.SetBool("isWalking", moveDirection != 0 && !isSpeaking);
        animator.SetBool("isSpeaking", isSpeaking);

        if (moveDirection != 0)
        {
            bool facingLeft = moveDirection < 0;
            spriteRenderer.flipX = facingLeft;

            // Fener ve canbarý yönünü ayarla
            if (lantern != null)
            {
                Vector3 scale = lantern.localScale;
                scale.x = facingLeft ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
                lantern.localScale = scale;
                lantern.localPosition = new Vector3(facingLeft ? -lanternOffset.x : lanternOffset.x, lanternOffset.y, 0);
            }

            if (canbari != null)
            {
                Vector3 scale = canbari.localScale;
                scale.x = facingLeft ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
                canbari.localScale = scale;
                canbari.localPosition = new Vector3(facingLeft ? -canbariOffset.x : canbariOffset.x, canbariOffset.y, 0);
            }
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
