using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour {

    public GameObject playerObject;
    public int lives = 3;
    public Text textObject;
    private GameObject playerInstance;
    private float respawnTimer;

    // Use this for initialization
    void Start() {
        textObject.text = "Lives: " + ++lives;
        Spawn();
    }

    void Spawn() {
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerObject);
        playerInstance.name = "Player";
        textObject.text = "Lives: " + --lives;
    }

    // Update is called once per frame
    void Update() {
        if (playerInstance == null) {
            respawnTimer -= Time.deltaTime;
            if (lives != 0) {
                if (respawnTimer <= 0) Spawn();
            }
            else{
                Debug.Log("GAME OVER!");
            }
        }
    }
}
