using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public Slider timerSlider;

    //Sets timer length
    public float sliderTimer;

    //Stop timer or not
    public bool stopTimer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(StartTheTimer());
        //Logic to respawn here wont work
    }

    IEnumerator StartTheTimer()
    {
        while (stopTimer == false)
        {
            sliderTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if(sliderTimer <= 0)
            {
                stopTimer = true;
                
                SceneManager.LoadScene("Loose screen");

            }

            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer;
            }
        }

        //add game logic here eg respawn
    }

    public void StopTimer()
    {

    }
}
