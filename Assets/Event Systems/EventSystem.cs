using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour {

    private GameOverSystem gameOverSystem;
    private ScoreSystem scoreSystem;
    private SoundSystem soundSystem;
    private string errorString = " script could not be found!\nCheck that the script is attached to EventSystem for this scene";

    public GameOverSystem GameOverSystem() {
        gameOverSystem = GameObject.Find("EventSystem").GetComponent<GameOverSystem>();
        if (gameOverSystem == null) {
            Debug.Break();
            throw new MissingComponentException("GameOverSystem" + errorString);
        }
        return gameOverSystem;
    }

    public ScoreSystem ScoreSystem() {
        scoreSystem = GameObject.Find("EventSystem").GetComponent<ScoreSystem>();
        if (scoreSystem == null) {
            Debug.Break();
            throw new MissingComponentException("ScoreSystem" + errorString);
        }
        return scoreSystem;
    }

    public SoundSystem SoundSystem() {
        soundSystem = GameObject.Find("EventSystem").GetComponent<SoundSystem>();
        if (soundSystem == null) {
            Debug.Break();
            throw new MissingComponentException("SoundSystem" + errorString);
        }
        return soundSystem;
    }
}
