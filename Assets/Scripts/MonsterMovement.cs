using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float lifeTime = 10f; // Time in seconds before auto-destroy

    public Transform target; // Set by the spawner
    public float speed = 0.05f;
    private Rigidbody rb;

    public PlayerManagement PM;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Schedule this monster to be destroyed after 'lifeTime' seconds
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        if (target == null) return;

        // Move towards the target (player)
        Vector3 direction = (target.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        transform.LookAt(target);
    }

    // This function runs when a TRIGGER (the bullet) enters this collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that hit me is tagged "Bullet"
        if (other.CompareTag("Bullet"))
        {
            // Find the ScoreManager and add 10 points
            ScoreManager.instance.AddScore(10);

            Destroy(other.gameObject); // Destroy the bullet
            Destroy(gameObject);       // Destroy myself (the monster)
        } else if (other.CompareTag("MainCamera")) // When touching the player
        {
            PM.TakeDamage(20); // Deal Damage to player

            Destroy(gameObject); // Destroy the enemy
        }
    }
}