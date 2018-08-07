using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageHandler : EventSystem {

    private float invulnTimer = 0;
    private int invulnLayer = 10;
    private int originalLayer;
    private Text healthText;
    private bool isPlayer = false;
    public int health = 1;

    // Use this for initialization
    void Start() {
        originalLayer = gameObject.layer;
        healthText = GameObject.Find("Canvas").transform.Find("Health").GetComponent<Text>();
        isPlayer = gameObject.CompareTag("Player");
        if (isPlayer) {
            health -= PlayerPrefs.GetInt("difficulty", 1) - 1;
            healthText.text = "Health: " + health;
        }
    }

    private void OnTriggerEnter2D() {
        health--;
        invulnTimer = 0.5f;
        gameObject.layer = invulnLayer;
        if (isPlayer){
            SoundSystem().PlayHit();
            healthText.text = "Health: " + health;
        }
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
            if (gameObject.CompareTag("Torpedo")) {
                // TODO: Maybe fix this to use something other than torpedo, an issue can arise if its a multi-hit enemy!
                SoundSystem().PlayHit();
                ScoreSystem().RaiseScore();
            }
            if (isPlayer) { 
                SoundSystem().PlayGameOver();
                GameOverSystem().GameOver();
            }
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
