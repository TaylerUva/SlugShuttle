using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameMode : MonoBehaviour {

	public Text gameModeText;
	private string gameModeString;

	// Classic = 1
	// Protection = 2
	// Survival = 3

	// Use this for initialization
	void Start() {
		updateText();
	}

	private void updateText() {
		int gameMode = PlayerPrefs.GetInt("gameMode", 1);
		switch (gameMode) {
			default : gameModeString = "Classic";
			break;
			case 2:
					gameModeString = "Protection";
				break;
			case 3:
					gameModeString = "Survival";
				break;
		}
		gameModeText.text = "GameMode:\n" + gameModeString;
	}

	public void CyclegameMode() {
		int gameMode = PlayerPrefs.GetInt("gameMode", 1);
		switch (gameMode) {
			case 1:
				PlayerPrefs.SetInt("gameMode", 2);
				break;
			case 2:
				PlayerPrefs.SetInt("gameMode", 3);
				break;
			case 3:
				PlayerPrefs.SetInt("gameMode", 1);
				break;
		}
		updateText();
	}
}