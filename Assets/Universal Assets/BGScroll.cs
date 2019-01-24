using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

	private float cameraWidth;
	private float cameraHeight;
	private float scaleValue;

	private Vector3 startPosition;

	void Start() {
		startPosition = transform.position;
	}

	void Update() {
		transform.localScale = new Vector3(CameraSize().x, 2 * CameraSize().y);
		GetComponent<Renderer>().sharedMaterial.SetTextureScale("_MainTex", new Vector2(CameraSize().x / 10, 2 * CameraSize().y / 10));
		float newPosition = Mathf.Repeat(Time.time * ScrollSpeed(), transform.localScale.y / 2);
		transform.position = startPosition + Vector3.down * newPosition;
	}

	Vector2 CameraSize() {
		cameraWidth = Camera.main.orthographicSize * Camera.main.aspect * 2f;
		cameraHeight = 2f * Camera.main.orthographicSize;
		return new Vector2(cameraWidth, cameraHeight);
	}

	Vector2 GetCameraSize() {
		cameraWidth = Camera.main.orthographicSize * Camera.main.aspect * 2f;
		cameraHeight = 2f * Camera.main.orthographicSize;
		return new Vector2(cameraWidth, cameraHeight);
	}

	float ScrollSpeed() {
		switch (PlayerPrefs.GetInt("difficulty", 1)) {
			default : return 2f;
			case 2:
					return 3f;
			case 3:
					return 4f;
		}
	}
}