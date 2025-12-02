using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    public int damageToPlayer = 10;
    public int pointsForBlocking = 5; //points eared for blocking

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        //can probably change to going towards the player camera
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //1. Check if we hit the SHIELD
        if (other.CompareTag("Shield"))
        {
            //Points for successful block
            ScoreManager.instance.AddScore(pointsForBlocking);
            //Destroy the projectile
            Destroy(gameObject);
        }
        else if (other.CompareTag("MainCamera")) {
            //Find the PlayerManagement script to deal damage
            PlayerManagement pm = other.GetComponent<PlayerManagement>();
            if (pm == null) pm = other.GetComponentInParent<PlayerManagement>();

            if (pm != null)
            {
                pm.TakeDamage(damageToPlayer);
            }
            Destroy(gameObject);
        }
    }
}
