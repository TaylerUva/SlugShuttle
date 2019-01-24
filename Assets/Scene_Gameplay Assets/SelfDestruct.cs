using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : EventSystem {

	Vector3 spriteSize;
	int gameMode;

	void Start() {
		gameMode = PlayerPrefs.GetInt("gameMode", 1);
		spriteSize = GetComponent<SpriteRenderer>().bounds.extents;
	}

	void Update() {
		float cameraHeightCord = Camera.main.orthographicSize;
		if (CompareTag("Enemy")) {
			if (transform.position.y < -(cameraHeightCord - spriteSize.y) && gameMode == 2) {
				DamagePlayer();
				Destroy(gameObject);
			} else if (transform.position.y < -(cameraHeightCord - spriteSize.y) && gameMode == 3) {
				ScoreSystem().RaiseScore();
				Destroy(gameObject);
			} else if (transform.position.y < -(cameraHeightCord + spriteSize.y) && CompareTag("Enemy")) Destroy(gameObject);
		}
		if (transform.position.y > (cameraHeightCord + spriteSize.y) && CompareTag("Torpedo")) Destroy(gameObject);
	}

	void DamagePlayer() {
		PlayerDamageHandler playerDamageHandler = GameObject.Find("Player").GetComponent<PlayerDamageHandler>();
		if (playerDamageHandler == null) {
			Debug.Break();
			throw new MissingComponentException("PlayerDamageHandler script could not be found!\nCheck that the script is attached to Player");
		} else {
			playerDamageHandler.DamagePlayer();
		}
	}
}