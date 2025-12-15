using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManger : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioMixer;

    public void SetMasterVolume(float level)
    {
        AudioMixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20f);
    }

    public void SetSoundsFXVolume(float level)
    {
        AudioMixer.SetFloat("SoundFX", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level)
    {
        AudioMixer.SetFloat("Music", Mathf.Log10(level) * 20f);
    }
}
