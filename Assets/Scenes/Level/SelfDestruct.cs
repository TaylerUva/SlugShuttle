using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float destroyTimer = 1f;
	
	// Update is called once per frame
	void Update () {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0) Destroy(gameObject);
	}
}
