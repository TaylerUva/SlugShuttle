using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
    
    public GameObject pauseMenu;
    public GameObject pauseButton;

    public void Pause(){
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume(){
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
