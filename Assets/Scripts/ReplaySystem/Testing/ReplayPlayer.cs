using UnityEngine;

public class ReplayPlayer : MonoBehaviour
{
    [Header("References")]
    public ObjectRecorder recorder;
    public Transform carTarget;
    public Transform cameraTarget;

    [Header("Playback")]
    public float playbackSpeed = 1f;

    private int index;
    private bool isReplaying;

    private Rigidbody rb;
    private CarMovement carMovement;
    private CameraFollow cameraFollow;

    void Start()
    {
        rb = carTarget.GetComponent<Rigidbody>();
        carMovement = carTarget.GetComponent<CarMovement>();
        cameraFollow = cameraTarget.GetComponent<CameraFollow>();
    }

    void FixedUpdate()
    {
        if (!isReplaying || recorder == null || recorder.recordedFrames.Count == 0)
            return;

        if (index >= recorder.recordedFrames.Count)
        {
            StopReplay();
            return;
        }

        FrameData frame = recorder.recordedFrames[index];

        // player
        rb.MovePosition(frame.playerPosition);
        rb.MoveRotation(frame.playerRotation);

        // camera
        cameraTarget.position = frame.cameraPosition;
        cameraTarget.rotation = frame.cameraRotation;

        index += Mathf.Max(1, Mathf.RoundToInt(playbackSpeed));
    }

    public void StartReplay()
    {
        if (recorder.recordedFrames.Count == 0)
            return;

        index = 0;
        isReplaying = true;
        recorder.isRecording = false;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        carMovement.enabled = false;
        cameraFollow.isReplaying = true;
    }

    public void StopReplay()
    {
        isReplaying = false;

        rb.isKinematic = false;
        carMovement.enabled = true;
        cameraFollow.isReplaying = false;
    }
}