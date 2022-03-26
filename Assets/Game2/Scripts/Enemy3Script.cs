using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Script : EnemyController

{// Start is called before the first frame update
    protected bool _check = false;
    
    void FixedUpdate()
    {
        if (_check)
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
    }

    public void MoveEnemy() 
    {
        _check = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Flip();
        }
    }
}
