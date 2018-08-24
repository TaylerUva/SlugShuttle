using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int speed = 5;
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, speed * (1+PlayerPrefs.GetInt("difficulty", 1)/5) * Time.deltaTime, 0);

        transform.position -= velocity;
	}
}
