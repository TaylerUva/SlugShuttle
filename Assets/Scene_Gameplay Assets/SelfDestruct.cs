using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : EventSystem {
	
    Vector3 spriteSize;

    void Start() {
        spriteSize = GetComponent<SpriteRenderer>().bounds.extents;
    }

	void LateUpdate () {
        float cameraHeightCord = Camera.main.orthographicSize;
        if (transform.position.y < -(cameraHeightCord+spriteSize.y) && CompareTag("Enemy")) Destroy(gameObject);
        if (transform.position.y > (cameraHeightCord + spriteSize.y) && CompareTag("Torpedo")) Destroy(gameObject);

    }
}
