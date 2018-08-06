using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : GameplayEventSystem {

    private float invulnTimer = 0;
    private int invulnLayer = 10;
    private int originalLayer;
    public int health = 1;

    // Use this for initialization
    void Start() {
        EventSystemInit();
        originalLayer = gameObject.layer;
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
            if (gameObject.CompareTag("Player")) ScoreSystem().LowerScore();
            if (gameObject.CompareTag("Enemy")) ScoreSystem().RaiseScore();
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
