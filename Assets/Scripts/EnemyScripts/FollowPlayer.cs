using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    
    void Update()
    {
        Vector3 playerpos = player.transform.position;
        Vector2 direction = new Vector2(playerpos.x - transform.position.x, playerpos.y - transform.position.y);
   
        transform.up = direction;
    }
}
