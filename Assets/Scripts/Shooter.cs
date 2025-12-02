using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign in inspector
    public Transform shootPoint; // Where the projectile spawns
    public float shootForce = 20f;

    public float shootInterval = 2f; // seconds between shots
    private float shootTimer = 0f;

    public PlayerManagement PM;

    // Color charge effect
    public Renderer chargeRenderer;
    public Color startColor = new Color(0.167f, 0.024f, 0.240f);
    public Color endColor = Color.white;

    void Update()
    {
        // Increment timer
        shootTimer += Time.deltaTime;

        // Lerp color of the charging projectile/core
        if (chargeRenderer != null)
        {
            float t = Mathf.Clamp01(shootTimer / shootInterval);
            chargeRenderer.material.color = Color.Lerp(startColor, endColor, t);
        }

        // Shoot when timer is done
        if (shootTimer >= shootInterval)
        {
            ShootProjectile();
            shootTimer = 0f;
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Projectile pr = projectile.GetComponent<Projectile>();
        pr.speed = shootForce;
        pr.PM = PM;
    }
}
