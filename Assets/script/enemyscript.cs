using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;          // vereceği hasar
    public float knockbackForce = 5f; // geri itme kuvveti

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
                // Yön belirleme (oyuncunun düşmana göre pozisyonu)
                Vector2 knockbackDir = (collision.transform.position - transform.position).normalized;
                rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}
