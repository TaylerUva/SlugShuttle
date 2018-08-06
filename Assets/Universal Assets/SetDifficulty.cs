using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDifficulty : MonoBehaviour {

    public Text difficultyText;
    private string difficultyString;


    // Use this for initialization
    void Start() {
        updateText();
    }

    private void updateText() {
        int difficulty = PlayerPrefs.GetInt("difficulty", 1);
        switch (difficulty) {
        default:
            difficultyString = "Easy";
            break;
        case 2:
            difficultyString = "Medium";
            break;
        case 3:
            difficultyString = "Hard";
            break;
        }
        difficultyText.text = "Difficulty:\n" + difficultyString;
    }

    public void CycleDifficulty() {
        int difficulty = PlayerPrefs.GetInt("difficulty", 1);
        switch (difficulty) {
        case 1:
            PlayerPrefs.SetInt("difficulty", 2);
            break;
        case 2:
            PlayerPrefs.SetInt("difficulty", 3);
            break;
        case 3:
            PlayerPrefs.SetInt("difficulty", 1);
            break;
        }
        updateText();
    }
}
