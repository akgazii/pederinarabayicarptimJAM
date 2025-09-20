using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 respawnPoint;
    private PlayerHealth playerHealth;
    private bool hasCheckpoint = false;

    void Start()
    {
        respawnPoint = transform.position; // İlk pozisyon (opsiyonel)
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void UpdateCheckpoint(Vector2 newPoint)
    {
        respawnPoint = newPoint;
        hasCheckpoint = true;
        Debug.Log("Checkpoint güncellendi: " + respawnPoint);
    }

    public bool Respawn()
    {
        if (!hasCheckpoint)
            return false; // Checkpoint yok, respawn yapma

        transform.position = respawnPoint;
        playerHealth.currentHealth = playerHealth.maxHealth;
        playerHealth.isDead = false;
        Debug.Log("Player respawn oldu.");
        return true; // Respawn başarılı
    }
}
