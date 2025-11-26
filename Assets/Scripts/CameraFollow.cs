using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform carPos;
    public Vector3 additionalOffset = new Vector3(0, 7, -7);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = carPos.position + additionalOffset;
        //transform.LookAt(camPos);
    }
}
