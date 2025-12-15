using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManger : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
        //audioMixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20f);
        audioMixer.SetFloat("MasterVolume", level);
    }

    public void SetSoundsFXVolume(float level)
    {
        //audioMixer.SetFloat("SoundFX", Mathf.Log10(level) * 20f);
        audioMixer.SetFloat("SoundFX", level);
    }

    public void SetMusicVolume(float level)
    {
        //audioMixer.SetFloat("Music", Mathf.Log10(level) * 20f);
        audioMixer.SetFloat("Music", level);
    }
}
