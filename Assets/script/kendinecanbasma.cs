using UnityEngine;
using System.Collections;

public class PlayerHealSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] healSprites;            // Heal animasyonu (frame-frame)
    public float frameTime = 0.1f;          // Her frame’in süresi
    public PlayerHealth playerHealth;       // PlayerHealth script
    public Animator animator;               // Idle.anim buradan oynatılıyor

    [Header("Disable During Heal")]
    public MonoBehaviour[] scriptsToDisable; // Yürüme, zıplama scriptlerini buraya ekle

    private bool isHealing = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isHealing)
        {
            StartCoroutine(PlayHealAnimation());
        }
    }

    IEnumerator PlayHealAnimation()
    {
        isHealing = true;

        // Idle animasyonu durdur
        animator.enabled = false;

        // Hareket scriptlerini kapat
        foreach (var s in scriptsToDisable)
        {
            s.enabled = false;
        }

        // Heal animasyonu frame-frame oynat
        for (int i = 0; i < healSprites.Length; i++)
        {
            spriteRenderer.sprite = healSprites[i];

            // 8. sprite’ta heal ver (index 7 = 8. sprite)
            if (i == 7)
            {
                playerHealth.Heal(1);
            }

            yield return new WaitForSeconds(frameTime);
        }

        // Hareket scriptlerini tekrar aç
        foreach (var s in scriptsToDisable)
        {
            s.enabled = true;
        }

        // Idle animasyonuna geri dön
        animator.enabled = true;
        isHealing = false;
    }
}
