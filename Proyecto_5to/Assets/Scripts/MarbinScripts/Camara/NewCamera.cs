using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    public float mouseSensitivity = 80f;
    float xRotation = 0;
    public float positiveX, negativeX;

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
        //xRotation = mouseY - VirtualCamera.m_Lens.LensShift.y;
        //xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, negativeX, positiveX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        VirtualCamera.Follow.Rotate(Vector3.up * mouseX);
    }
}
