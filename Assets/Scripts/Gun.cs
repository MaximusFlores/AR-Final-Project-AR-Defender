using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your Bullet prefab in the Inspector
    public Transform firePoint;

    void Start()
    {
         if (firePoint == null)
            firePoint = transform;
    }

    void Update()
    {
        // Check for screen tap (mouse click in editor)
        /*if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // Check if the tap is on the "gun" side of the screen
            if (Input.mousePosition.x > Screen.width / 2 || Input.GetTouch(0).position.x > Screen.width/2)
            {
                Shoot();
            }
        }*/
    }

    public void Shoot()
    {
        // Spawn a bullet at the gun's position and rotation
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}