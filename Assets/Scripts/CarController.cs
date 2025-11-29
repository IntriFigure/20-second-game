using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    [Header("Speed")]
    public float MoveSpeed = 100;
    public float MaxSpeed = 40;
    public bool isGrounded;

    [Header("Drift/Trun")]
    public float Drag = 0.98f;
    public float SteerAngle = 20;
    public float Traction = 1;

    public float maxTurnAngle;

    private Vector3 MoveForce;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float caRforward = Input.GetAxis("Vertical");
        if (isGrounded)
            caRforward = 1;
        else
        {
            caRforward = 0;
        }
        //moving
        MoveForce += transform.forward * MoveSpeed * caRforward * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        //steering
        //float steerInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        // STEERING CLAMP EXPLANATION
        float steerInput = Input.GetAxis("Horizontal");
        // get current Y rotation in the world spaces
        float yRotation = transform.eulerAngles.y;
        // convert 270 → -90 so that it can be read as  180 and -180 
        if (yRotation > 180f) yRotation -= 360f;
        // add steering into the yRotation to convert into the 180 and -180 
        yRotation += steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime;
        // clamp yRotation to between maxTurnAngle in degree
        yRotation = Mathf.Clamp(yRotation, -maxTurnAngle, maxTurnAngle);
        // apply the clamped yRotation to the car's transform 
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);


        //drag
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        //traction
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        } else
        {
            //isGrounded = false;
            StartCoroutine(AirBorned());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //isGrounded = false;
        StartCoroutine(AirBorned());
    }

    // END GAME //because the car movement isnt base on physics it will take longer for OnCollision to detect the wall 
                //So i create a bigger boxcollider to dectect on trigger collision for a faster to respones.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") || (other.CompareTag("BonceWall")))
        {
            Debug.Log("Hit");
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    IEnumerator AirBorned()
    {
        yield return new WaitForSeconds(0.2f);
        isGrounded = false;
    }
}
