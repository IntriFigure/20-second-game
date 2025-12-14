using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject carPos;
    public GameObject fpsCam;
    public GameObject tpsCam;

    [Header("Third Person Functions")]
    public Vector3 thirdPersonOffSet = new Vector3(0, 7, -7);

    [Header("First Person Functions")]
    public bool isFirstPerson;
    public Vector3 firstPersonOffSet = new Vector3(0, 7, -7);
    public Camera playerCamera;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;

    [Header("Throw pIzzA Functions")]
    public GameObject pizzaBox;
    public Transform ThrowOrigin;
    public float throwForce = 10f;
    public bool canShoot = true;
    public float ThrowRate;
    public CarMovement carM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        carM = GameObject.Find("Car 2 (W/Rigidbody)").GetComponent<CarMovement>();
    }

    private void Update()
    {
        if (isFirstPerson)
        {
            pizzaBox.SetActive(true);
            // free look camera
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // Vertical camera rotation (look up/down)
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -30f, 40f);

            yRotation += mouseX;
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);
            // Apply BOTH rotations to the camera
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);


            //// THROW PIZZA FUNCTION ///
            if (Input.GetKey(KeyCode.Mouse0) && canShoot)
            {
                ThrowPizzAFunction();
                StartCoroutine(CanShootCD());
            }               
        } 
        else
        {
            pizzaBox.SetActive(false);
        }       
    }

    void ThrowPizzAFunction()
    {
        GameObject prefb =Instantiate(pizzaBox, ThrowOrigin.position, Quaternion.identity);
        Rigidbody pizzaRB = prefb.GetComponent<Rigidbody>();

        float shootWVelocity = throwForce * carM.currentCarSpeed;       
        pizzaRB.AddForce(transform.forward * shootWVelocity, ForceMode.Impulse);

        /*Vector3 forceDirection = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500f))
        {
            forceDirection = (hit.point - ThrowOrigin.position).normalized;
        }

        if (pizzaRB != null)
        {
            float shootWVelocity = throwForce * carM.currentCarSpeed;
            Vector3 forceToAdd = forceDirection * shootWVelocity;// + transform.up * throwUpwardForce;
            pizzaRB.AddForce(forceToAdd, ForceMode.Impulse);
        }  */
        Destroy(prefb, 3f);
    }
   
    // Update is called once per frame
    void LateUpdate()
    {
        if (!isFirstPerson)
        {
            fpsCam.SetActive(false);
            tpsCam.SetActive(true);
            transform.rotation = Quaternion.Euler(20f, 0f, -0.072f);//new Vector3(20f, 0f, -0.072f);
            transform.position = carPos.transform.position + thirdPersonOffSet;
        }
        else
        {         
            fpsCam.SetActive(true);
            tpsCam.SetActive(false);
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = carPos.transform.TransformPoint(firstPersonOffSet);
            //transform.rotation = carPos.transform.rotation;
        }
    }

    IEnumerator CanShootCD()
    {
        canShoot = false;
        yield return new WaitForSeconds(ThrowRate);
        canShoot = true;
    }
}

