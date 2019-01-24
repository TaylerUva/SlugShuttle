using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageHandler : EventSystem {

	private float invulnTimer = 0;
	private int invulnLayer = 10;
	private int originalLayer;
	public int health = 1;
	public bool doesInvuln = false;

	// Use this for initialization
	void Start() {
		originalLayer = gameObject.layer;
	}

	private void OnTriggerEnter2D() {
		health--;
		invulnTimer = 0.5f;
		if (doesInvuln) {
			gameObject.layer = invulnLayer;
		}
		if (gameObject.CompareTag("Enemy")) {
			ScoreSystem().RaiseScore();
		}
	}

	// Update is called once per frame
	void Update() {
		invulnTimer -= Time.deltaTime;
		if (invulnTimer <= 0) {
			gameObject.layer = originalLayer;
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		} else {
			gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
		}
		if (health <= 0) {
			if (gameObject.CompareTag("Enemy")) {
				EffectsSoundSystem().PlayerHit();
			}
			Destroy(gameObject);
		}
	}
}