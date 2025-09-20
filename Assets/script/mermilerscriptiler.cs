using UnityEngine;

public class mermilerscriptiler : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;

    public int damage = 1; // Her mermi kaç hasar vuracak

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Çarptı: " + hitInfo.name);

        EnemyHealth enemyHealth = hitInfo.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
