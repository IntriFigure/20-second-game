using UnityEngine;

public class ReplayController : MonoBehaviour
{
    public PlayerRecorder replay;

    void Update()
    {
        // Press R to start replay
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Stop recording
            replay.recorder.isRecording = false;

            // Start replay
            replay.StartReplay();
        }
    }
}