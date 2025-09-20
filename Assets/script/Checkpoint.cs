using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite activeSprite;
    private SpriteRenderer sr;
    void Start()
    {
    sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
             if (collision.CompareTag("Player"))
             {   
                  collision.GetComponent<PlayerRespawn>().UpdateCheckpoint(transform.position);
                  sr.sprite = activeSprite; // checkpoint sprite değişir
            }
}
}
