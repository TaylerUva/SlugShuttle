using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighscore : MonoBehaviour {

	public Text highscoreText;

	public void ResetHighscore() {
		PlayerPrefs.SetInt("highscore", 0);
		highscoreText.text = "Highscore:\n" + PlayerPrefs.GetInt("highscore");
	}

	private void OnEnable() {
		highscoreText.text = "Highscore:\n" + PlayerPrefs.GetInt("highscore", 0);
	}
}