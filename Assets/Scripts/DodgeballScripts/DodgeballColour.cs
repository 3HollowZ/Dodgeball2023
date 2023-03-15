using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeballColour : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }
}
