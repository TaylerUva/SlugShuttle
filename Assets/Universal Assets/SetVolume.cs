using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour {

    public bool isMusicSlider = false;

    private void OnValidate() {
        if (isMusicSlider) GetComponent<Slider>().value = PlayerPrefs.GetFloat("musicVolume", 1.0f);
        else GetComponent<Slider>().value = PlayerPrefs.GetFloat("effectsVolume", 1.0f);
    }

    public void SetEffectsVolume(float sliderValue) {
        PlayerPrefs.SetFloat("effectsVolume", sliderValue);
    }

    public void SetMusicVolume(float sliderValue) {
        PlayerPrefs.SetFloat("musicVolume", sliderValue);
    }
}
