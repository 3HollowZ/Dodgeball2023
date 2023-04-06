using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int maxEnemies = 15;
    [SerializeField] private int enemiesPerSpawn = 2;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnDelay = 1f; // delay before spawning starts
    [SerializeField] private float spawnXMin = 0.54f; // minimum x value for spawn position
    [SerializeField] private float spawnXMax = 10.7f; // maximum x value for spawn position

    private float timer;

    // Update is called once per frame
    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Check if it's time to spawn
        if (timer > spawnInterval && Time.timeSinceLevelLoad > spawnDelay && GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            // Reset timer
            timer = 0f;

            // Code to spawn enemies within x range
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                float randomX = Random.Range(spawnXMin, spawnXMax);
                Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                // Code to make enemies move randomly
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.StartMoving();
                }
            }
        }
    }
}
