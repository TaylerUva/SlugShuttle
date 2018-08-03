using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
	
	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;
        if (Time.timeScale != 0) {
            if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0) {
                //Shoot
                cooldownTimer = fireDelay;

                Vector3 torpedoPos = transform.position;
                torpedoPos.y += 1;
                torpedoPos.z += 1;

                Instantiate(bulletPrefab, torpedoPos, transform.rotation);
            }
        }
	}
}
