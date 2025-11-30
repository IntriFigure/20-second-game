using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject carPos;

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
    public float throwUpwardForce = 10f;
    public bool canShoot = true;
    public float ThrowRate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (isFirstPerson)
        {
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
        
    }

    void ThrowPizzAFunction()
    {
        GameObject prefb =Instantiate(pizzaBox, ThrowOrigin.position, Quaternion.identity);
        Rigidbody pizzaRB = prefb.GetComponent<Rigidbody>();

        Vector3 forceDirection = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500f))
        {
            forceDirection = (hit.point - ThrowOrigin.position).normalized;
        }

        if (pizzaRB != null)
        {
            Vector3 forceToAdd = forceDirection * throwForce;// + transform.up * throwUpwardForce;
            pizzaRB.AddForce(forceToAdd, ForceMode.Impulse);
        }
            

        Destroy(prefb, 3f);
    }
   
    // Update is called once per frame
    void LateUpdate()
    {
        if (!isFirstPerson)
        {
            transform.rotation = Quaternion.Euler(20f, 0f, -0.072f);//new Vector3(20f, 0f, -0.072f);
            transform.position = carPos.transform.position + thirdPersonOffSet;
        }
        else
        {
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

