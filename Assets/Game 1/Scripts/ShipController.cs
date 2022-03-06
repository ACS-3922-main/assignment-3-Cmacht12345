using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour{

    [SerializeField] GameObject _shot;

    private float _speed = 5;
    private float _boundary = 3.5f;
    Rigidbody2D _rb;
    Animator _anim;
    private bool _alive = true;
    [SerializeField] private AudioSource _audioShot;
    [SerializeField] private AudioSource _explosion;

    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update(){
        Vector2 vel = _rb.velocity;
        if (Input.GetKey(KeyCode.RightArrow)) {
            vel.x = _speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            vel.x = -_speed;
        }
        else {
            vel.x = 0;
        }
        _rb.velocity = vel;

        Vector3 pos = transform.position;
        if (pos.x > _boundary) {
            pos.x = _boundary;
        }
        else if (pos.x < -_boundary) {
            pos.x = -_boundary;
        }
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space)) {
            _audioShot.Play();
            Instantiate(_shot, new Vector3(transform.position.x,
                transform.position.y, 0.5f), Quaternion.identity);

        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "AShot") {
            //Destroy(gameObject);
            Destroy(other.gameObject);
            if (_alive) {
                GameObject lives = GameObject.Find("Canvas");
                lives.GetComponent<Manager>().Health();
                _explosion.Play();
                _alive = false;
                _anim.SetBool("die", false);
                Vector3 ship = transform.position;
                ship.x = 0;
                transform.position = ship;
                Invoke("RestartGame", 3.00f);
            }
        }
    }

    private void RestartGame() {
            _anim.SetBool("die", true);
            _alive = true;
    }
}
