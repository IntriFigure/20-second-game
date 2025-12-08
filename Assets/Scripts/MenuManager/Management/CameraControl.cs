using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject thePlayer;

    public float offSetX;
    public float offSetY;
    public float speedOffSet;

    void Update()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = thePlayer.transform.position;

        // use offset
        endPos.x += offSetX;
        endPos.y += offSetY;
        endPos.z = -10;

        //move the camera
        transform.position = Vector3.Lerp(startPos, endPos, speedOffSet * Time.deltaTime);
    }
}

