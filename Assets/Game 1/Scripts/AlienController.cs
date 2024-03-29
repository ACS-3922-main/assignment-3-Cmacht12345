using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour{

    [SerializeField] GameObject _ashot;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Shot") {
            Destroy(gameObject);
            Destroy(other.gameObject);
            AudioSource audio = GameObject.Find("AliensFactory").GetComponent<AudioSource>();
            audio.Play();
            GameObject lives = GameObject.Find("Canvas");
            lives.GetComponent<Manager>().Score();
        }
    }

    private void Update() {
        if (Mathf.FloorToInt(Random.value * 10000.0f) % 5000 == 0) {
            Instantiate(_ashot, new Vector3(transform.position.x,
                transform.position.y, 0.5f), Quaternion.identity);
        }
    }
}
