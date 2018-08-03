using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseGame : MonoBehaviour {

    private bool isPaused = false;
    public GameObject pauseMenu;

    void Start() {
        Resume();
    }

    public void Pause(){
        Time.timeScale = 0;
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void Resume(){
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
    }
}
