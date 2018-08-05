using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighscore : MonoBehaviour {

    public Text highscoreText;

	// Use this for initialization
	void Start () {
        highscoreText.text = "Highscore:\n" + PlayerPrefs.GetInt("highscore");
	}
}