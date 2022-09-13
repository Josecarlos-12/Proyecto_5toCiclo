using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    //public MoveRigiFisi move;

    public float mouseSensitivity = 80f;
    public Transform playerBody;
    public Transform cameraBody;
    float xRotation = 0;

    public Transform pointA;
    public Transform pointB;

    public GameObject pointer;

    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        cameraBody.Rotate(0f,0f,0f);
        cameraBody.transform.position = pointA.position;
        pointer.SetActive(false);
        weapon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Point();
        MoveCamera();
    }

    public void Point()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            weapon.enabled = true;
            pointer.SetActive(true);
            cameraBody.transform.position = pointB.position;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            weapon.enabled = false;
            pointer.SetActive(false);
            cameraBody.transform.position = pointA.position;
        }
    }

    public void MoveCamera()
    {
        //if (move.moveAll)
        //{            
        //}
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
