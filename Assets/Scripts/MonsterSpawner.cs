using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab; // Assign your Monster prefab in the Inspector
    public float spawnRate = 2.0f;   // Spawn a monster every 2 seconds
    public float monsterSpeed = 1.0f;
    
    private float timer;
    private Transform playerCamera;

    void Start()
    {
        // Find the player (the AR Camera is tagged "MainCamera" by default)
        playerCamera = Camera.main.transform;
    }

    void Update()
    {
        // This script is on the GameManager, which is a child of the Image Target.
        // This Update() function will only run when the target is being tracked.
        
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnMonster();
            timer = 0f;
        }
    }

    void SpawnMonster()
    {
        // Spawn the monster at this object's position (which is the image target)
        GameObject monster = Instantiate(monsterPrefab, transform.position, transform.rotation);
        
        // Get the monster's movement script and tell it who to chase
        MonsterMovement movement = monster.AddComponent<MonsterMovement>();
        movement.target = playerCamera;
        movement.speed = monsterSpeed;
    }
}