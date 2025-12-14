using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsFXManger : MonoBehaviour
{
    public static SoundsFXManger instant;

    private void Awake()
    {
        if (instant == null)
        {
            instant = this;
        }
    }

    public void PlaySoundFXclip(AudioClip audioClip, Transform spawnTransform )
    {

    }
}
