using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform[] spawnPoints = new Transform[8]; 


    public int numberOfEnemies = 20; // Number of enemies to spawn
    public float spawnDelay = 2f; // Delay between enemy spawns

    private int enemiesSpawned = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay); // Start spawning enemies with a delay
    }

    void SpawnEnemy()
    {
        if (enemiesSpawned >= numberOfEnemies)
        {
            CancelInvoke("SpawnEnemy");
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length); 
        Transform spawnPoint = spawnPoints[spawnPointIndex];

        // Instantiate an enemy at the chosen spawn point
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Increment the number of spawned enemies
        enemiesSpawned++;
    }
}
