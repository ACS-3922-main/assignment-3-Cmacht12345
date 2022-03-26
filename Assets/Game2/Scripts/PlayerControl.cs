using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed = 4.5f;
    [SerializeField] private float _jumpForce = 12.0f;
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Vector3 _checkPosition;
    private bool _checkPoint = false;
    private Rigidbody2D _rb;
    Animator _anim;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        Vector2 movement = new Vector2(deltaX, _rb.velocity.y);
        _rb.velocity = movement;

        _anim.SetFloat("speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if (!_checkPoint)
            {
                transform.position = _startPos;
            }
            else 
            {
                transform.position = _checkPosition;
            }   
        }

        if(other.gameObject.tag == "NextLevel") 
        {
            _checkPoint = false;
            transform.position = _startPos;
            Debug.Log("Winner!");
        }
    }

    public void CheckPoint() 
    {
        _checkPosition = transform.position;
        _checkPoint = true;
    }
    

    private void OnCollisionExit2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
}
