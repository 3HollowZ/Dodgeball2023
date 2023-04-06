using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public string playerTag = "Player";

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            Vector3 playerpos = player.transform.position;
            Vector2 direction = new Vector2(playerpos.x - transform.position.x, playerpos.y - transform.position.y);
            transform.up = direction;
        }
    }
}
