using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour {

    private GameOverSystem gameOverSystem;
    private ScoreSystem scoreSystem;
    private EffectsSoundSystem effectsSoundSystem;
    private GameModeSystem gameModeSystem;
    private PlayerDamageHandler playerDamageHandler;
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

    public EffectsSoundSystem EffectsSoundSystem() {
        effectsSoundSystem = GameObject.Find("EventSystem").GetComponent<EffectsSoundSystem>();
        if (effectsSoundSystem == null) {
            Debug.Break();
            throw new MissingComponentException("EffectsSoundSystem" + errorString);
        }
        return effectsSoundSystem;
    }

    public GameModeSystem GameModeSystem(){
        gameModeSystem = GameObject.Find("EventSystem").GetComponent<GameModeSystem>();
        if (gameModeSystem == null) {
            Debug.Break();
            throw new MissingComponentException("GameModeSystem" + errorString);
        }
        return gameModeSystem;
    }
}
