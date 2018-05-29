using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

    public AudioClip crack;
    public AudioClip explotion;
    public Sprite[] hitSprites;
    public GameObject smoke;
    public static int brickCount = 0;

    private int timesHits;
    private LevelManager levelManager;
    bool isBreakable;

    // Use this for initialization
    void Start() {
        isBreakable = (tag == "Breakable");

        if (isBreakable) {
            brickCount++;
        }

        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHits = 0;
    }

    void OnCollisionExit2D(Collision2D other) {
        if (isBreakable) {
            HandleHits();
        }

    }

    private void HandleHits() {
        timesHits++;
        int maxHits = hitSprites.Length + 1;
        if (timesHits >= maxHits) {
            DestroyBrick();
        } else {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            LoadSprites();
        }
    }

    private void DestroyBrick() {
        brickCount--;
        levelManager.BrickDestroyed();
        SmokePuff();
        AudioSource.PlayClipAtPoint(explotion, transform.position);
        Destroy(gameObject);
    }

    private void SmokePuff() {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites() {
        int spriteIndex = timesHits - 1;
        if (hitSprites[spriteIndex] != null) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Brick Sprite Missing");
        }

    }
}
