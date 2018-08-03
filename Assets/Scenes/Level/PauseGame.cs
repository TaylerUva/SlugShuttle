using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseGame : MonoBehaviour {
    
    public GameObject pauseMenu;

    public void Pause(){
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume(){
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
