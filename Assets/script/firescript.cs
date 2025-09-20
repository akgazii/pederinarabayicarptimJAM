using UnityEngine;

public class firescript : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public float fireCooldown = 0.2f; // Kaç saniyede bir mermi atılsın
    private float nextFireTime = 0f;

    void Update()
    {
        // R'ye basılı tutuluyorsa ateş et
        if (Input.GetKey(KeyCode.R) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
