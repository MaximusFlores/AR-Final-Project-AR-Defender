using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;

    void Start()
    {
        // Get the bullet's Rigidbody and shoot it forward
        GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
        // Destroy the bullet after 3 seconds if it hits nothing
        Destroy(gameObject, lifeTime);
    }
}