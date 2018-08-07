using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsSoundSystem : MonoBehaviour {

    public AudioClip gameOverSound;
    public AudioClip shootSound;
    public AudioClip hitSound;
    private AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>();
        if (source == null) {
            Debug.Break();
            throw new MissingComponentException("AudioSource component could not be found!\nCheck that the component is attached to EventSystem for this scene");
        }
    }

    public float GetEffectsVolume() {
        return PlayerPrefs.GetFloat("effectsVolume", 1.0f);
    }

    public void PlayGameOver() {
        source.PlayOneShot(gameOverSound, GetEffectsVolume());
    }

    public void PlayShoot() {
        source.PlayOneShot(shootSound, GetEffectsVolume());
    }

    public void PlayHit() {
        source.PlayOneShot(hitSound, GetEffectsVolume());
    }
}
