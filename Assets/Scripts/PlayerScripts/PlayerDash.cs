using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance;
    public float dashSpeed;

    private Rigidbody2D rb2d;
    private Vector2 dashDirection;
    private PlayerController movementController;

    private bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movementController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        dashDirection = new Vector2(horizontalInput, verticalInput).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        if (PlayerController.instance.currentStamina >= 5)
        {
            PlayerController.instance.UseStamina(5);
            canMove = false;
            rb2d.velocity = Vector2.zero;
            rb2d.isKinematic = true;

            // Disable the player's ability to move during the dash
            movementController.canMove = false;
            rb2d.velocity = Vector2.zero;
            rb2d.isKinematic = true;

            // Calculate the dash endpoint based on the specified dash distance and direction
            Vector2 dashEndpoint = rb2d.position + (dashDirection * dashDistance);

            // Move the player towards the dash endpoint at the specified dash speed
            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime * dashSpeed;
                rb2d.MovePosition(Vector2.Lerp(rb2d.position, dashEndpoint, t));
                yield return null;
            }

            // Re-enable the player's ability to move after the dash is complete
            movementController.canMove = true;
            rb2d.isKinematic = false;
        }
    }
}
