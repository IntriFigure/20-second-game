using UnityEngine;

public class newCarController : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentsteeringAngle;

    public bool NoMesh = false;

    [SerializeField] private float gasInput;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider FRWheel;
    [SerializeField] private WheelCollider FLWheel;
    [SerializeField] private WheelCollider RRWheel;
    [SerializeField] private WheelCollider RLWheel;

    [SerializeField] private MeshRenderer FRWheelMesh;
    [SerializeField] private MeshRenderer FLWheelMesh;
    [SerializeField] private MeshRenderer RRWheelMesh;
    [SerializeField] private MeshRenderer RLWheelMesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //speed = rb.linearVelocity.magnitude;
        GetInput();
        HandleMotorPower();
        HandleWheelPos();
        ApplySteering();
        
    }

    void GetInput()
    {
        verticalInput = Input.GetAxis("Vertical"); //forwards just make it automatic forward
        horizontalInput = Input.GetAxis("Horizontal"); //LR
    }

    void HandleMotorPower()
    {
        verticalInput = 1f;
        RRWheel.motorTorque = verticalInput * gasInput;
        RLWheel.motorTorque = verticalInput * gasInput;
    }
    void ApplySteering()
    {

        currentsteeringAngle = maxSteeringAngle * horizontalInput;
        FLWheel.steerAngle = currentsteeringAngle;
        FRWheel.steerAngle = currentsteeringAngle;
    }

    void HandleWheelPos()
    {
        UpdateWheel(FLWheel, FLWheelMesh);
        UpdateWheel(FRWheel, FRWheelMesh);
        UpdateWheel(RRWheel, RRWheelMesh);
        UpdateWheel(RLWheel, RLWheelMesh);
    }
    void UpdateWheel(WheelCollider coll, MeshRenderer wheelMesh)
    {
        Quaternion quat;
        Vector3 position;
        coll.GetWorldPose(out position, out quat);
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = quat;
    }
}

