using UnityEngine;

public class EnemyChargeAttack : MonoBehaviour
{
    public Sprite[] sprites;      
    public float frameTime = 0.2f; 
    public float chargeDelay = 1.5f;
    public float attackForce = 8f;
    public Transform player;      

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isCharging = false;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = chargeDelay;
    }

    void Update()
    {
        if (player == null) return;

        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
        timer -= Time.deltaTime;
        if (timer <= 0f && !isCharging)
        {
            StartCoroutine(ChargeAttack());
            timer = chargeDelay;
        }
    }

    System.Collections.IEnumerator ChargeAttack()
    {
        isCharging = true;

        for (int i = 0; i < sprites.Length; i++)
        {
            spriteRenderer.sprite = sprites[i];

            if (i >= sprites.Length - 2) //2spritedadashler
            {
                Vector2 dashDir = (player.position - transform.position).normalized;
                rb.AddForce(new Vector2(dashDir.x, 0) * attackForce, ForceMode2D.Impulse);
            }

            yield return new WaitForSeconds(frameTime);
        }

        isCharging = false;
    }
}
