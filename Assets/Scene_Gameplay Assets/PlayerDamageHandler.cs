using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageHandler : EventSystem {

	private float invulnTimer = 0;
	private int invulnLayer = 10;
	private int originalLayer;
	private Text healthText;
	public int health = 1;

	// Use this for initialization
	void Start() {
		originalLayer = gameObject.layer;
		healthText = GameObject.Find("Canvas").transform.Find("Health").GetComponent<Text>();
		health -= PlayerPrefs.GetInt("difficulty", 1) - 1;
		healthText.text = "Health: " + health;
	}

	private void OnTriggerEnter2D() {
		DamagePlayer();
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
			EffectsSoundSystem().PlayGameOver();
			GameOverSystem().GameOver();
			Destroy(gameObject);
		}
	}

	public void DamagePlayer() {
		health--;
		invulnTimer = 0.5f;
		gameObject.layer = invulnLayer;
		EffectsSoundSystem().PlayerHit();
		healthText.text = "Health: " + health;
	}
}