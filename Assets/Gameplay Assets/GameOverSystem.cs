using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSystem : MonoBehaviour {

    public GameObject gameOverMenu;

    public void GameOver() {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
