using UnityEngine;

public class EnemyChargeAttack1 : MonoBehaviour
{
    public Sprite[] sprites;      
    public float aframeTime = 0.2f; 
    public float achargeDelay = 1.5f;
    public float aattackForce = 8f;
    public Transform player;      

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isCharging = false;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = achargeDelay;
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
            timer = achargeDelay;
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
                rb.AddForce(new Vector2(dashDir.x, 0) * aattackForce, ForceMode2D.Impulse);
            }

            yield return new WaitForSeconds(aframeTime);
        }

        isCharging = false;
    }
}
