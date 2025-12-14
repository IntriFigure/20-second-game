using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsFXManger : MonoBehaviour
{
    public static SoundsFXManger instant;
    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instant == null)
        {
            instant = this;
        }
    }

    public void PlayRandomSoundFXclip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        //random index
        int rand = Random.Range(0, audioClip.Length);

        // object spawn 
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        // assign the audio
        audioSource.clip = audioClip[rand];

        // assign volume 
        audioSource.volume = volume;

        // play sounds
        audioSource.Play();

        //get legnth of sound fx clip
        float clipLength = audioSource.clip.length;

        //destroy clip after finish playing 
        Destroy(audioSource.gameObject, clipLength);
    }
}
