using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManagerScript gameManager;
    public int maxHealth = 5;
    public int currentHealth;
    public bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        Debug.Log("Hasar alındı! Can: " + currentHealth);

        // Can sıfıra düşünce bir kere çalışsın
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameover();
            Debug.Log("Dead");
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        Debug.Log("İyileşti! Can: " + currentHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            TakeDamage(1);

        if (Input.GetKeyDown(KeyCode.L))
            Heal(1);
    }
}
