using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f; // speed
    public float moveDistance = 2f; // change this value for different heights
    public float moveRange = 2f; // range for random movement
    public int scoreValue = 100; // value to add to score on death

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Get starting position
        startPosition = transform.position;
        targetPosition = GetNewRandomPosition();

        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if enemy has reached target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Get new random position
            targetPosition = GetNewRandomPosition();
        }

        // Move towards target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    // Call this method to start movement
    public void StartMoving()
    {
        enabled = true;
    }

    // Call this method to stop movement
    public void StopMoving()
    {
        enabled = false;
    }

    // Get new random position
    private Vector3 GetNewRandomPosition()
    {
        float x = startPosition.x + Random.Range(-moveRange, moveRange);
        float y = startPosition.y + Random.Range(-moveRange, moveRange);
        float z = startPosition.z + Random.Range(-moveRange, moveRange);
        return new Vector3(x, y, z);
    }

    // Called when enemy is destroyed
    private void OnDestroy()
    {
        if (gameManager != null)
        {
            gameManager.AddScore(scoreValue);
        }
    }
}
