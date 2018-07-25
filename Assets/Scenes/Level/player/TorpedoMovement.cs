using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoMovement : MonoBehaviour {

    public int torpedoSpeed = 10;
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, torpedoSpeed * Time.deltaTime, 0);

        transform.position += velocity;
	}
}
