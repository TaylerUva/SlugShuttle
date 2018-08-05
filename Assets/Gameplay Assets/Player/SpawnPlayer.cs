using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour {

    public GameObject playerObject;
    public int lives = 3;
    public Text textObject;
    public GameObject gameOverMenu;
    private bool isGameOver = false;
    private bool wasLifeLost = false;
    private GameObject playerInstance;
    private float respawnTimer;

    // Use this for initialization
    void Start() {
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

    void GameOver(){
        isGameOver = true;
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        if (lives >= 0 && playerInstance == null && !isGameOver){
            if (!wasLifeLost) {
                --lives;
                wasLifeLost = true;
                if (lives >= 0) textObject.text = "Lives: " + lives;
                else GameOver();
            }
            if (DoneRespawning()){
                Spawn();
            }
        }
    }
}
