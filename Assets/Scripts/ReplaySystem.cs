using System.Collections.Generic;
using UnityEngine;
public class ReplaySystem : MonoBehaviour
{
    private bool isReplayMode;
    private Rigidbody rigidbody;
    private List<ReplayTarget> replayTarget = new List<ReplayTarget>();

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            isReplayMode = !isReplayMode;
            if (isReplayMode)
            {
                setTransform(0);
                rigidbody.isKinematic = true;
            }
            else
            {
                setTransform(replayTarget.Count - 1);
                rigidbody.isKinematic = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isReplayMode == false)
        {
            replayTarget.Add(new ReplayTarget { position = transform.position, rotation = transform.rotation });
        }
    }

    private void setTransform(int index)
    {
        //ReplayTarget replayTarget = replayTarget[index];

        //transform.position = replayTarget.position;
        //transform.rotation = replayTarget.rotation;
    }

}
