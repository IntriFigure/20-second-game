using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{
    [Header("Speed")]
    public float currentCarSpeed;
    public float moveSpeed;
    public float maxSpeed = 20f;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    public bool grounded;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    Rigidbody rb;

    [Header("Drift/Trun")]
    public bool noDrifting;
    [Range(0f, 0.95f)] public float driftStrenght = 0.95f;   // how much sideways grip is removed
    public float turnStrength = 5f;
    public float maxTurnAngle;
    private float carRotationY;

    [Header("SteeringWheel")]
    public Transform steeringWheel;
    private float zSteerRotation;

    [Header("Bounce/Orientation")]
    public bool hitWall;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        //verticalInput = 1f; //Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    private void Update()
    {
        MyInput();
        grounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        //rotate the steering Wheel
        zSteerRotation = steeringWheel.rotation.eulerAngles.z;
        if (zSteerRotation > 180f) zSteerRotation -= 360f;

        zSteerRotation = carRotationY * -1;
        steeringWheel.localRotation = Quaternion.Euler(31.025f, 0f, zSteerRotation);
    }

    void FixedUpdate()
    {
        //physics based movement should always be in fixed update
        MovePlayer();

        // car current Speed
        Vector3 currentVelocity = rb.linearVelocity;
        currentCarSpeed = currentVelocity.magnitude;
    }

    private void MovePlayer()
    {
        // Always move forward if on ground
        if (grounded)
        {
            // Automatically moving Forward //!!! goesfaster as time goes on!!!
            rb.AddForce(orientation.forward * moveSpeed, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(orientation.forward * (moveSpeed / 2), ForceMode.Acceleration);
        }

        // your speed limit
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // ignore vertical velocity

        if (flatVel.magnitude > maxSpeed)
        {
            // Clamp only horizontal movement
            flatVel = flatVel.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(flatVel.x, rb.linearVelocity.y, flatVel.z);
        }


        // Steering rotation
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, horizontalInput * turnStrength, 0f));

        if (!noDrifting || grounded)
        {
            // Drift reduce sideways velocity  
            Vector3 localVel = transform.InverseTransformDirection(rb.linearVelocity);
            //remove sideways grip
            localVel.x *= Mathf.Lerp(1f, driftStrenght, Mathf.Abs(horizontalInput));

            rb.linearVelocity = transform.TransformDirection(localVel);
        }

        // clamping car rotation to max of positive and negartive 90 degrees
        carRotationY = rb.rotation.eulerAngles.y;

        if (carRotationY > 180f) carRotationY -= 360f;
        carRotationY += horizontalInput * turnStrength;
        carRotationY = Mathf.Clamp(carRotationY, -maxTurnAngle, maxTurnAngle);
        rb.MoveRotation(Quaternion.Euler(0f, carRotationY, 0f));

        //for car reorientation
        /*yRotation = transform.rotation.eulerAngles.y;
        if (yRotation > 180f) yRotation -= 360f;*/

    }

    // no movement when airborn! // use raycast next time
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Wall"))
        {
            Debug.Log("DIE");
            SceneManager.LoadScene("GreyBox");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BonceWall"))
        {
            // once the collider hit the wall tag/layer
            // reorient player back to face forward
            rb.MoveRotation(Quaternion.Euler(0, 0, 0));

            //cast a ray 
            // hit.nomral
            // addforce.impules

            /*if (yRotation > 10)
            {
                rb.MoveRotation(Quaternion.Euler(0f, 0f, 0f));
                // add this back when bounce back is added
                rb.AddTorque(Vector3.up * 10f, ForceMode.Impulse);
                Debug.Log("Rotate Left");
            }
            else 
            if (yRotation < -10)
            {
                rb.MoveRotation(Quaternion.Euler(0f, 0f, 0f));
                // add this back when bounce back is added
                rb.AddTorque(Vector3.down * 10f, ForceMode.Impulse);
                Debug.Log("Rotate Right");
            }*/
        }
    }
    // double check just incase //no movement when airborn!
}
