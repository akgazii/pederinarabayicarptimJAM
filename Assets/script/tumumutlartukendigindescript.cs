using UnityEngine;

public class boxl : MonoBehaviour
{
    public int damage = 1;          
    public float knockbackForce = 5f; //geriitis

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }

            if (rb != null)
            {
                Vector2 knockbackDir = (collision.transform.position - transform.position).normalized;
                rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}
