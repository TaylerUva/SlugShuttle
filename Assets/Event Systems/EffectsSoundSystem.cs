using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsSoundSystem : MonoBehaviour {

    private AudioClip sound;
    private AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>();
        if (source == null) {
            Debug.Break();
            throw new MissingComponentException("AudioSource component could not be found!\nCheck that the component is attached to EventSystem for this scene");
        }
    }

    public float GetEffectsVolume() {
        return PlayerPrefs.GetFloat("effectVolume", 1.0f);
    }

    public void PlayGameOver() {
        source.PlayOneShot(Resources.Load<AudioClip>("Audio/gameOver"), GetEffectsVolume());
    }

    public void PlayShoot() {
        source.PlayOneShot(Resources.Load<AudioClip>("Audio/shoot"), GetEffectsVolume());
    }

    public void PlayHit() {
        source.PlayOneShot(Resources.Load<AudioClip>("Audio/hit"), GetEffectsVolume());
    }
}
