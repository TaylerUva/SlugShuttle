using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepAlive : MonoBehaviour {

	void Awake() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");
		if (objs.Length > 1)
			Destroy(this.gameObject);

		DontDestroyOnLoad(this.gameObject);
	}

	void Update() {
		// Destroy on certain scenes
		//if (SceneManager.GetActiveScene().name == "SceneName") {
		//    Destroy(this.gameObject);
		//}
	}
}