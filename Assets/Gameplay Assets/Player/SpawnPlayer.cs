using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour {

    public GameObject playerObject;
    public int lives = 3;
    public Text textObject;
    private GameOverSystem gameOverSystem;
    private bool wasLifeLost = false;
    private GameObject playerInstance;
    private float respawnTimer;

    // Use this for initialization
    void Start() {
        EventSystemInit();
        textObject.text = "Lives: " + lives;
        Spawn();
    }

    void EventSystemInit() {
        gameOverSystem = GameObject.Find("EventSystem").GetComponent<GameOverSystem>();
        if (gameOverSystem == null) Debug.LogError("Cannot find 'GameOverSystem' script\nCheck that the script is attached to EventSystem");
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
                else gameOverSystem.GameOver();
            }
            if (DoneRespawning()){
                Spawn();
            }
        }
    }
}
