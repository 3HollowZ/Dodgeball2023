using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float speed;
    public float stamina;

    public Rigidbody2D rb2d;

    public bool canMove = true;

    public int maxStamina = 20;
    public int currentStamina;
    public int regenRate = 1;

    private DodgeballThrow dodgeballThrow;
    private float throwCooldown = 2f;

    private IEnumerator RegenerateStamina()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); // Wait for 1 second before regenerating stamina
            RestoreStamina(regenRate);
        }
    }

    private void Start()
    {
        StartCoroutine(RegenerateStamina()); // Start the coroutine for stamina regeneration
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            currentStamina = maxStamina;
        }
        else
        {
            Destroy(gameObject);
        }

        rb2d = GetComponent<Rigidbody2D>();
        currentStamina = maxStamina;

        dodgeballThrow = GetComponent<DodgeballThrow>();
        throwCooldown = 2f;

    }


    private void Update()
    {
        if (canMove)
        {
            Movement();
        }
        else
        {
            Debug.Log("canMove is false");
        }

        if (Input.GetMouseButtonDown(0))
        {
            dodgeballThrow.ThrowBall();
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        rb2d.velocity = movement * speed;

    }
    public void UseStamina(int amount)
    {
        currentStamina -= amount;
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }
    public void RestoreStamina(int amount)
    {
        currentStamina += amount;
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }


}
