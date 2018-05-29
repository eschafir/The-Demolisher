using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour {

    public static int lifes = 3;
    private Text lifeText;

    private void Start() {
        if (GameObject.FindGameObjectWithTag("LifeCant") != null) {
            lifeText = GameObject.FindGameObjectWithTag("LifeCant").GetComponent<Text>();
        }
    }


    private void Update() {
        if (lifeText != null && lifes >= 0) {
            lifeText.text = lifes.ToString();
        }

        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5) {
            Cursor.visible = true;
        } else {
            Cursor.visible = false;
        }
    }

    public void LoadLevel(string levelName) {
        Bricks.brickCount = 0;
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel() {
        Bricks.brickCount = 0;
        int actualScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(actualScene + 1);
    }

    public void LoseLevel() {
        SceneManager.LoadScene("Lose");


    }

    public void QuitRequest() {
        Debug.Log("Quiting game.");
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
        lifes = 3;
    }

    public void BrickDestroyed() {
        if (Bricks.brickCount <= 0) {
            LoadNextLevel();
        }
    }

    public void TryAgain() {
        Ball ball = GameObject.FindObjectOfType<Ball>();
        lifes--;
        ball.RestartPosition();
        ball.StartGame();
    }
}