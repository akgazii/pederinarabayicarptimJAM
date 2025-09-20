using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameoverUI;
    private PlayerRespawn playerRespawn;

    void Start()
    {
        playerRespawn = FindObjectOfType<PlayerRespawn>(); // Oyuncuyu bul
    }

    public void gameover()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0f; // oyun durdurulsun
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void mainmanu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void respawn()
    {
        Time.timeScale = 1;
        gameoverUI.SetActive(false);
        playerRespawn.Respawn(); // Player’ı checkpointten doğur
    }
}
