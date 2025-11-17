using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    // --- ADD THIS LINE ---
    public float lifeTime = 10f; // Time in seconds before auto-destroy

    public Transform target; // Set by the spawner
    public float speed = 1.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // --- ADD THIS LINE ---
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
            Destroy(other.gameObject); // Destroy the bullet
            Destroy(gameObject);       // Destroy myself (the monster)
        }
    }
}