using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    // Update is called once per frame
    void Update() {
        if (!autoPlay) {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
    }

    void AutoPlay() {
        Ball ball = GameObject.FindObjectOfType<Ball>();
        gameObject.transform.position = new Vector2(ball.transform.position.x, gameObject.transform.position.y);
    }

    void MoveWithMouse() {
        Vector3 paddlePos = new Vector3(8f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }
}
