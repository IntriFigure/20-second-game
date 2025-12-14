using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManger : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioMixer;

    public void SetMasterVolume(float level)
    {
        AudioMixer.SetFloat("masterVOlume", Mathf.Log10(level) * 20f);
    }

    public void SetSoundsFXVolume(float level)
    {
        AudioMixer.SetFloat("soundsFXVolume", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level)
    {
        AudioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20f);
    }
}
