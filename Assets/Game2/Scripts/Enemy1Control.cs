using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Control : EnemyController
{
    // Start is called before the first frame update

    void FixedUpdate()
    {
        if (_isFacingRight == true)
        {
            _rb.velocity =
            new Vector2(_maxSpeed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity =
            new Vector2(_maxSpeed * -1, _rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Wall") 
        {
            Flip();
        }
    }
}
