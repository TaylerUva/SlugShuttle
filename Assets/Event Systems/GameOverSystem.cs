using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSystem : MonoBehaviour {

    public GameObject gameOverMenu;
    public GameObject pauseButton;

    public void GameOver() {
        gameOverMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
}
