using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

    public GameObject playerObject;
    private GameObject playerInstance;
    private float respawnTimer;
    // Use this for initialization
    void Start() {
        Spawn();
    }

    void Spawn() {
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerObject);
        playerInstance.name = "Player";
    }

    // Update is called once per frame
    void Update() {
        if (playerInstance == null) {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0) Spawn();
        }
    }
}
