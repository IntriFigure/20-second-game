using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{
    [Header("Speed")]
    public float moveSpeed;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    public bool grounded;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    Rigidbody rb;

    [Header("Drift/Trun")]
    public float driftFactor = 0.95f;   // how much sideways grip is removed
    public float turnStrength = 5f;
    public float maxTurnAngle;
    

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

    }
    void FixedUpdate()
    {
        //physics based movement should always be in fixed update
        MovePlayer();
    }

   private void MovePlayer()
    {
        // Always move forward if on ground
        if (grounded)
        {
            // Automatically moving Forward //!!! goesfaster as time goes on!!!
            rb.AddForce(orientation.forward * moveSpeed, ForceMode.Acceleration);
        }

        float maxSpeed = 20f; // your speed limit
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // ignore vertical velocity

        if (flatVel.magnitude > maxSpeed)
        {
            // Clamp only horizontal movement
            flatVel = flatVel.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(flatVel.x, rb.linearVelocity.y, flatVel.z);
        }


        // Steering rotation
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, horizontalInput * turnStrength, 0f));

        // Drift reduce sideways velocity
        Vector3 localVel = transform.InverseTransformDirection(rb.linearVelocity);
        //remove sideways grip
        localVel.x *= Mathf.Lerp(1f, driftFactor, Mathf.Abs(horizontalInput));
        rb.linearVelocity = transform.TransformDirection(localVel);

        // clamping car rotation to max of positive and negartive 90 degrees
        float y = rb.rotation.eulerAngles.y;

        if (y > 180f) y -= 360f;
        y += horizontalInput * turnStrength;
        y = Mathf.Clamp(y, -maxTurnAngle, maxTurnAngle);
        rb.MoveRotation(Quaternion.Euler(0f, y, 0f));

    }

    // no movement when airborn! // use raycast next time
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Wall"))
        {
            Debug.Log("DIE");
            SceneManager.LoadScene("SampleScene");
        }
    }
    // double check just incase //no movement when airborn!
}
