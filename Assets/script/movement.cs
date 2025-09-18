using UnityEngine;

public class box : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float zipla = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // Yatay hareket
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Karakter yönü (FlipX)
        if (move > 0)
            spriteRenderer.flipX = false;  // sağa bak
        else if (move < 0)
            spriteRenderer.flipX = true;   // sola bak

        // Zıplama
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * zipla, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
