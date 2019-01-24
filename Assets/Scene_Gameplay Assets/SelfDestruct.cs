using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	Vector3 spriteSize;

	void Start() {
		spriteSize = GetComponent<SpriteRenderer>().bounds.extents;
	}

	void Update() {
		float cameraHeightCord = Camera.main.orthographicSize;
		if (CompareTag("Enemy")) {
			if (transform.position.y < -(cameraHeightCord - spriteSize.y) && PlayerPrefs.GetInt("gameMode") == 2) {
				DamagePlayer();
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