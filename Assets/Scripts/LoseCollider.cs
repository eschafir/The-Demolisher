using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (LevelManager.lifes <= 0) {
            levelManager.LoseLevel();
        } else {
            levelManager.TryAgain();
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {

    }
}
