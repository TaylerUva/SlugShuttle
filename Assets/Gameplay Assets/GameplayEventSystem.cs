using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayEventSystem : MonoBehaviour {

    private GameOverSystem gameOverSystem;
    private ScoreSystem scoreSystem;

    public void EventSystemInit(){
        gameOverSystem = GameObject.Find("EventSystem").GetComponent<GameOverSystem>();
        if (gameOverSystem == null) Debug.LogError("Cannot find 'GameOverSystem' script\nCheck that the script is attached to EventSystem in the Gameplay Scene");

        scoreSystem = GameObject.Find("EventSystem").GetComponent<ScoreSystem>();
        if (scoreSystem == null) Debug.LogError("Cannot find 'ScoreSystem' script\nCheck that the script is attached to EventSystem in the Gameplay Scene");
    }

    public GameOverSystem GameOverSystem(){
        return gameOverSystem;
    }

    public ScoreSystem ScoreSystem() {
        return scoreSystem;
    }
}
