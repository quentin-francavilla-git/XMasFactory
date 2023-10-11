using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    Slider slider;
    [SerializeField]
    Sound.audioType type;
    AudioManager audioManager;

    void Awake()
    {
        slider = GetComponent<Slider>();
        audioManager = FindObjectOfType<AudioManager>();

        // slider.value = PlayerPrefs.GetFloat(type+"Volume");
        slider.value = 0.5f;
    }

    public void updateVolume(float newVolume)
    {
        audioManager.changeVolume(type, slider.value);
    }
}
