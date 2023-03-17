using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeballThrow : MonoBehaviour
{
    public float throwSpeed;
    public GameObject ballPrefab;
    public float throwCooldown = 1.5f; // The minimum time (in seconds) between throws

    private Rigidbody2D rb2d;
    private float lastThrowTime = -Mathf.Infinity;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > lastThrowTime + throwCooldown)
        {
            ThrowBall();
            lastThrowTime = Time.time;
        }
    }

    public void ThrowBall()
    {
        // Create a new instance of the ball prefab
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);

        // Ignore collisions between the ball and the player
        Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        // Calculate the direction to throw the ball
        Vector2 throwDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - ball.transform.position).normalized;

        // Apply a force to the ball in the calculated direction
        Rigidbody2D rb2d = ball.GetComponent<Rigidbody2D>();
        rb2d.velocity = throwDirection * throwSpeed;

        // Destroy the ball after 2 seconds
        Destroy(ball, 4f);

        // Set the gravity scale to 0
        rb2d.gravityScale = 0;
    }
}
