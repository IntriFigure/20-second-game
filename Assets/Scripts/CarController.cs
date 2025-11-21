using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{

    public float MoveSpeed = 50;

    private Vector3 MoveForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moving
        MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;
    }
}
