using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
/*    public GameObject SoundSettingCanvas;
    public AudioSource winMusic;
    public AudioSource loseMusic;*/

    private void Start()
    {
/*        winMusic.volume = PlayerPrefs.GetFloat("MasterVolume");
        loseMusic.volume = PlayerPrefs.GetFloat("MasterVolume");*/
    }

    public void DisableCanvas()
    {
/*        SoundSettingCanvas.SetActive(false);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click);*/
    }

    public void EnableCanvas()
    {
/*        SoundSettingCanvas.SetActive(true);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click);*/
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("PlayScene");
/*        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click);*/
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
/*        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click);*/
    }

    public void ExitGame()
    {
        Application.Quit();
/*        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click);*/
    }






    /*    maybe add in intruction?
         
          public void Instruction()
    {
        SceneManager.LoadScene("Instructions");
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click);
    }*/
}
