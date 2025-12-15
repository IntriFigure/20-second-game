using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManger : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider soundFXSlider;
    [SerializeField] private Slider musicSlider;
    private void Start()
    {
        float master = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float soundFX = PlayerPrefs.GetFloat("SoundFX", 1f);
        float music = PlayerPrefs.GetFloat("Music", 1f);

        SetMasterVolume(master);
        SetSoundsFXVolume(soundFX);
        SetMusicVolume(music);

        masterSlider.SetValueWithoutNotify (master);
        soundFXSlider.SetValueWithoutNotify ( soundFX);
        musicSlider.SetValueWithoutNotify ( music);
    }

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20f);
        //audioMixer.SetFloat("MasterVolume", level);
        PlayerPrefs.SetFloat("MasterVolume", level);
    }

    public void SetSoundsFXVolume(float level)
    {
        audioMixer.SetFloat("SoundFX", Mathf.Log10(level) * 20f);
        //audioMixer.SetFloat("SoundFX", level);
        PlayerPrefs.SetFloat("SoundFX", level);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(level) * 20f);
        //audioMixer.SetFloat("Music", level);
        PlayerPrefs.SetFloat("Music", level);
    }
}
