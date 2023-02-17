using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[
    //REFERENCES
    //Dash Tutorial - https://www.youtube.com/watch?v=w4YV8s9Wi3w
    //]

    //Basics
    public float speed;
    public float stamina;

    public Rigidbody2D rb;

    //Dash Variables
    private Vector2 moveInput;
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 1f;
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = speed;
    }


    private void Update()
    {
        Movement();

    }


    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(horizontal, vertical);

        rb.velocity = moveInput * speed;
    }


    private void Dash()//Doesn't Work RN
    {
        rb.velocity = moveInput * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <=0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}
