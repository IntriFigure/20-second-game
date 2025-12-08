using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalCheckpoint : Timer
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEnter");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("CollisionExit");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Duck")
        {
            Debug.Log("TriggerEnter");
            timeRemaining = 10;
        }
    }
/*        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Duck")
        {
            Debug.Log("TriggerExit");
        }
    }*/

}
