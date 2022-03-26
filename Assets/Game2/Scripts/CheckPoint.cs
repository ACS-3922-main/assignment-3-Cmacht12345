using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerControl>().CheckPoint();
            player = GameObject.Find("EnemyNotActive");
            player.GetComponent<Enemy3Script>().MoveEnemy();
        }
    }
}
