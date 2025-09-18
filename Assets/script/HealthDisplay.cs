using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image[] hearts;      // Inspector'dan istediğin kadar ekle
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth.currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            hearts[i].enabled = i < playerHealth.maxHealth;
        }
    }
}
