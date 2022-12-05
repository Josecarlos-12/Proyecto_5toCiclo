using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{
    public SensibilityMouse sen;

    public bool moveCamera;
    public Transform playerBody;
    public float mouseSensitivity = 80f;
    float xRotation = 0;
    public float positiveX, negativeX;


    [Range(0f, 1f)]
    public float t;
    public float speed;

    public Transform pointA;
    public Transform pointB;
    public Transform cameraMain;

    public MoveRGB speeds;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    public void MoveCamera()
    {
        if (moveCamera)
        {
            mouseSensitivity = sen.sensibility.value+40;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, negativeX, positiveX);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
            //gun.Rotate(new Vector3(-1 * mouseY,0, 0) );
        }

    }

}
