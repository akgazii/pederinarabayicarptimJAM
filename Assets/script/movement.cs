using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float maxYVelocity = 25f; // Yukarı çıkış hızı sınırı

    [Header("Ground Check")]
    public Transform groundCheck;       // Ayak altına bir empty objesi koy
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;       // Yalnızca "Ground" layer’ına bak

    [Header("Components")]
    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded = false;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        // Yatay hareket
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Animasyon koşma kontrolü
        animator.SetBool("isRunning", move != 0);

        // Karakter yönünü döndürme (scale ile)
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        // Zıplama (sadece yerdeyken)
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // önce Y hızını sıfırla
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }

        // Y ekseni hız sınırı
        if (rb.velocity.y > maxYVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxYVelocity);
        }
    }

    void FixedUpdate()
    {
        // Ground check (circle overlap)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
