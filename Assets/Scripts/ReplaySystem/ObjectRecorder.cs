using System.Collections.Generic;
using UnityEngine;

public class ObjectRecorder : MonoBehaviour
{
    [Header("Targets")]
    public Transform playerTarget;
    public Transform cameraTarget;

    [Header("Recording")]
    public bool isRecording = true;

    public List<FrameData> recordedFrames = new List<FrameData>();

    void FixedUpdate()
    {
        if (!isRecording)
        {
            return;
        }

        recordedFrames.Add(
            new FrameData(
                playerTarget.position,
                playerTarget.rotation,
                cameraTarget.position,
                cameraTarget.rotation
            )
        );
    }

    public void Clear()
    {
        recordedFrames.Clear();
    }
}