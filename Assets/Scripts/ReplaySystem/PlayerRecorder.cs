using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    public ObjectRecorder recorder;
    public Transform targetToReplay;
    public float playbackSpeed = 1f;

    private int index = 0;
    private bool isReplaying = false;

    // reference to movement script
    private CarMovement movement; 

    void Start()
    {
        movement = targetToReplay.GetComponent<CarMovement>();
    }

    void Update()
    {
        if (!isReplaying)
            return;

        // Disable the movement controller during replay
        if (movement != null)
            movement.enabled = false;

        if (index < recorder.recordedFrames.Count)
        {
            FrameData frame = recorder.recordedFrames[index];

            //targetToReplay.position = frame.position;
            //targetToReplay.rotation = frame.rotation;

            index += Mathf.CeilToInt(playbackSpeed);
        }
        else
        {
            StopReplay();
        }
    }

    public void StartReplay()
    {
        index = 0;
        isReplaying = true;
    }

    public void StopReplay()
    {
        isReplaying = false;

        if (movement != null)
            // re-enable movement after replay
            movement.enabled = true; 
    }
}