using UnityEngine;

[System.Serializable]
public class FrameData
{
    public Vector3 position;
    public Quaternion rotation;

    public FrameData(Vector3 pos, Quaternion rot)
    {
        position = pos;
        rotation = rot;
    }
}