using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    private float invulnTimer = 0;
    private int invulnLayer = 10;
    private int originalLayer;
    public int health = 1;

    // Use this for initialization
    void Start() {
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
        if (invulnTimer <= 0) gameObject.layer = originalLayer;
        if (health <= 0) Die();
    }

    private void Die() {
        Destroy(gameObject);
    }
}
