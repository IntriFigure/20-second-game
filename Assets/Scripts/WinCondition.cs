using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private AudioSource audioSource;
    public AudioClip soundEffectClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PizzaBox"))
        {
            Debug.Log("Pizza Delievered!!!!! load to end screen or something"); //load to end screen or something.
            audioSource.PlayOneShot(soundEffectClip, 1.0f);
            StartCoroutine(SoundDelay());
        }
    }
    IEnumerator SoundDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("End Screen");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
