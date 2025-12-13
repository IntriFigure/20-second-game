using UnityEngine;

[System.Serializable]
public class FrameData
{
    public Vector3 playerPosition;
    public Quaternion playerRotation;
    public Vector3 cameraPosition;
    public Quaternion cameraRotation;

    public FrameData(Vector3 pos, Quaternion rot, Vector3 camPos, Quaternion camRot)
    {
        playerPosition = pos;
        playerRotation = rot;
        cameraPosition = camPos;
        cameraRotation = camRot;
    }
}