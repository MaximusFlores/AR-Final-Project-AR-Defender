using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab; // Assign your Monster prefab in the Inspector
    public float spawnRate = 2.0f;   // Spawn a monster every 2 seconds
    public float monsterSpeed = 1.0f;

    public float spawnRadius = 0.2f;
    
    private float timer;
    private Transform playerCamera;

    public PlayerManagement PM;

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

        //
        // 1. Generate a random point inside a circle
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;

        // 2. Calculate the spawn position using Y and Z axes
        // transform.up      = Local Y axis
        // transform.forward = Local Z axis
        Vector3 spawnPos = transform.position + 
                           (transform.forward * randomPoint.x) + 
                           (transform.up * randomPoint.y);



        // Spawn the monster at this object's position (which is the image target)
        GameObject monster = Instantiate(monsterPrefab, spawnPos, transform.rotation);
        
        // Get the monster's movement script and tell it who to chase
        
        MonsterMovement movement = monster.GetComponent<MonsterMovement>();
        
        // Safety check: Add it if it's missing
        if (movement == null) movement = monster.AddComponent<MonsterMovement>();


        movement.target = playerCamera;
        movement.speed = monsterSpeed;
        movement.PM = PM;
    }
}