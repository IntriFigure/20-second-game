using System.Collections.Generic;
using UnityEngine;

public class ObjectRecorder : MonoBehaviour
{
    [Header("Target to Record")]
    public Transform target;

    [Header("Recording Settings")]
    public bool isRecording = true;
    public float recordInterval = 0f;

    [HideInInspector]
    public List<FrameData> recordedFrames = new List<FrameData>();

    private float timer = 0f;

    void Update()
    {
        if (!isRecording || target == null)
            return;

        timer += Time.deltaTime;

        if (timer >= recordInterval)
        {
            recordedFrames.Add(new FrameData(target.position, target.rotation));
            timer = 0f;
        }
    }

    public void ClearRecording()
    {
        recordedFrames.Clear();
    }
}