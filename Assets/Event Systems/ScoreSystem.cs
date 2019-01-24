using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

	private int score = 0;
	private int highscore;
	private int difficulty;
	public Text scoreText;

	// Use this for initialization
	private void Start() {
		highscore = PlayerPrefs.GetInt("highscore", 0);
		difficulty = PlayerPrefs.GetInt("difficulty", 1);
		score = 0;
		UpdateScore();
	}

	public void RaiseScore() {
		switch (difficulty) {
			default : score += 10;
			break;
			case 2:
					score += 30;
				break;
			case 3:
					score += 50;
				break;
		}
		UpdateScore();
	}

	public void LowerScore() {
		switch (difficulty) {
			default : score -= 10;
			break;
			case 2:
					score -= 30;
				break;
			case 3:
					score -= 50;
				break;
		}
		UpdateScore();
	}

	private void UpdateScore() {
		scoreText.text = "Score: " + score;
		if (score > highscore) PlayerPrefs.SetInt("highscore", score);
	}
}