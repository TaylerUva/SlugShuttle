using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : EventSystem {

	public GameObject bulletPrefab;

	private float fireDelay = 0.25f;
	private float cooldownTimer = 0;

	private void Start() {
		fireDelay = PlayerPrefs.GetInt("difficulty", 1) / 10.0f;
	}

	// Update is called once per frame
	void Update() {
		cooldownTimer -= Time.deltaTime;
		if (PlayerPrefs.GetInt("gameMode", 1) == 3) {

		} else if (Time.timeScale != 0) {
			if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0) {
				//Shoot
				cooldownTimer = fireDelay;

				Vector3 torpedoPos = transform.position;
				torpedoPos.y += 1;
				torpedoPos.z += 1;
				Instantiate(bulletPrefab, torpedoPos, transform.rotation);
				EffectsSoundSystem().PlayShoot();
			}
		}
	}
}