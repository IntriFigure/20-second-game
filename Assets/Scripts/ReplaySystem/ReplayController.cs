using UnityEngine;

public class ReplayController : MonoBehaviour
{
    public ReplayPlayer replay;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            replay.StartReplay();
        }
    }
}
