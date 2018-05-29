using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 ballToPaddleDistance;
    private bool hasStarted;

    // Use this for initialization
    void Start() {
        paddle = GameObject.FindObjectOfType<Paddle>();
        ballToPaddleDistance = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted) {
            StartGame();
        }
    }


    private void OnCollisionEnter2D(Collision2D other) {
        Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted) {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

    public void StartGame() {
        RestartPosition();
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
    }

    public void RestartPosition() {
        hasStarted = false;
        this.transform.position = paddle.transform.position + ballToPaddleDistance;
    }
}
