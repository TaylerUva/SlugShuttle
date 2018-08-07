using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

    private AudioClip sound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void Awake() {
        source = GetComponent<AudioSource>();;
        if (source == null) {
            Debug.Break();
            throw new MissingComponentException("AudioSource component could not be found!\nCheck that the component is attached to EventSystem for this scene");
        }
    }

    public float CheckEffectVolume(){
        return PlayerPrefs.GetFloat("effectVolume", 1.0f);
    }

    public void PlayGameOver() {
        source.PlayOneShot(Resources.Load<AudioClip>("Audio/gameOver"), CheckEffectVolume());
    }
}
