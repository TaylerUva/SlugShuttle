using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : GameplayEventSystem {

    public GameObject playerObject;
    public int lives = 3;
    public Text textObject;
    private bool wasLifeLost = false;
    private GameObject playerInstance;
    private float respawnTimer;

    // Use this for initialization
    void Start() {
        EventSystemInit();
        textObject.text = "Lives: " + lives;
        Spawn();
    }

    void Spawn() {
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerObject);
        playerInstance.name = "Player";
        wasLifeLost = false;
    }

    bool DoneRespawning(){
        respawnTimer -= Time.deltaTime;
        return (respawnTimer <= 0);
    }

    // Update is called once per frame
    void Update() {
        if (lives >= 0 && playerInstance == null){
            if (!wasLifeLost) {
                --lives;
                wasLifeLost = true;
                if (lives >= 0) textObject.text = "Lives: " + lives;
                else GameOverSystem().GameOver();
            }
            if (DoneRespawning()){
                Spawn();
            }
        }
    }
}
