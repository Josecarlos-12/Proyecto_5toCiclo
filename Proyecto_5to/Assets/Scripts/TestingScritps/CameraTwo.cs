using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTwo : MonoBehaviour
{
    public float mouseSensitivity = 80f;
    public Transform playerBody;
    public Transform cameraBody;
    float xRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
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
