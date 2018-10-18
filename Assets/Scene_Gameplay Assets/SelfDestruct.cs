using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : EventSystem {
	
	// Update is called once per frame
	void Update () {
        float cameraHeightCord = Camera.main.orthographicSize;
        Vector3 spriteSize = GetComponent<SpriteRenderer>().bounds.extents;
        if (transform.position.y < -(cameraHeightCord+spriteSize.y) && CompareTag("Enemy")) Destroy(gameObject);
        if (transform.position.y > (cameraHeightCord + spriteSize.y) && CompareTag("Torpedo")) Destroy(gameObject);

    }
}
