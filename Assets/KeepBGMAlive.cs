using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepBGMAlive : MonoBehaviour {

    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroyMusic");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

    }

    void Update() {
        // Change BGMusic
        //if (SceneManager.GetActiveScene().name == "SceneName") {
        //    Destroy(this.gameObject);
        //}
    }
}
