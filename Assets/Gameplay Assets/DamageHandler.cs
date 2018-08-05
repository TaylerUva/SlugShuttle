using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    private float invulnTimer = 0;
    private int invulnLayer = 10;
    private int originalLayer;
    private ScoreSystem scoreSystem;
    public int health = 1;

    // Use this for initialization
    void Start() {
        originalLayer = gameObject.layer;
        scoreSystemInit();
    }

    private void scoreSystemInit(){
        GameObject scoreSystemObject = GameObject.Find("ScoreSystem");
        if (scoreSystemObject != null) {
            scoreSystem = scoreSystemObject.GetComponent<ScoreSystem>();
        }
        if (scoreSystem == null) {
            Debug.Log("Cannot find 'ScoreSystem' script");
        }
    }

    private void OnTriggerEnter2D() {
        health--;
        invulnTimer = 0.5f;

        gameObject.layer = invulnLayer;
    }

    // Update is called once per frame
    void Update() {
        invulnTimer -= Time.deltaTime;
        if (invulnTimer <= 0) {
            gameObject.layer = originalLayer;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        } 
        else {
            gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
        }
        if (health <= 0) {
            if (gameObject.CompareTag("Enemy")) scoreSystem.raiseScore();
            if (gameObject.CompareTag("Player")) scoreSystem.lowerScore();
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
