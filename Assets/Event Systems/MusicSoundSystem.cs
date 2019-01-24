using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSoundSystem : MonoBehaviour {

	public AudioClip music;
	private AudioSource source;
	float currentVolume;

	void Awake() {
		source = GetComponent<AudioSource>();
		if (source == null) {
			Debug.Break();
			throw new MissingComponentException("AudioSource component could not be found!\nCheck that the component is attached to Background for this scene");
		}

	}

	private void Start() {
		currentVolume = GetMusicVolume();
		PlayMusic();
	}

	public float GetMusicVolume() {
		return PlayerPrefs.GetFloat("musicVolume", 0.5f);
	}

	public void PlayMusic() {
		source.clip = music;
		source.loop = true;
		source.volume = GetMusicVolume();
		source.Play();
	}

	public void Update() {
		if (currentVolume != GetMusicVolume()) {
			currentVolume = source.volume = GetMusicVolume();
		}
	}
}