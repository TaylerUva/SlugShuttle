using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public bool yAxisEnabled = true;
	private float maxSpeed = 10;
	private float moveX;
	private float moveY;
	private float cameraWidth;
	private int gameMode;

	private void Start() {
		gameMode = PlayerPrefs.GetInt("gameMode", 1);
	}

	// Update is called once per frame
	void Update() {
		PlayerMove();
		cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
	}

	void PlayerMove() {
		Vector3 pos = transform.position;
		// CONTROLS
		pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
		if (yAxisEnabled) pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;

		// SCREEN BOUNDS
		if (gameMode != 3) {
			if ((pos.x) > cameraWidth) pos.x = -cameraWidth;
			if ((pos.x) < -cameraWidth) pos.x = cameraWidth;
		} else {
			if ((pos.x) > cameraWidth) pos.x = cameraWidth;
			if ((pos.x) < -cameraWidth) pos.x = -cameraWidth;
		}

		transform.position = pos;
	}
}