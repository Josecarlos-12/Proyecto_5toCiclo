using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class Walking : MonoBehaviour
{
    public float mouseSensitivity = 80f;
    public float speed;
    public Rigidbody rb;
    public Vector3 movementVector = Vector3.zero;
    public CinemachineFreeLook cinemachineFreeLook;
    public float xRotation;
    public Transform tranformPlayer;
    public Transform cameraVirutal;

    public GameObject virtualCamera;
    public GameObject freelockCamera;
    public bool point;
    public Transform playerBody;
    public float gravity;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        rb = GetComponent<Rigidbody>();
        virtualCamera.SetActive(false);
        freelockCamera.SetActive(true);
    }
    void Update()
    {
        Point();
        Move();
    }

    public void Point()
    {
        if (Input.GetMouseButtonDown(1))
        {
            virtualCamera.SetActive(true);
            freelockCamera.SetActive(false);
            point = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {           
            virtualCamera.SetActive(false);
            freelockCamera.SetActive(true);
            point = false;
        }
        if (Input.GetMouseButton(0)&&!point)
        {
            Cammera();
        }
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 velocity = Vector3.zero;

        if (horizontal != 0 || vertical != 0)
        {
            

            movementVector = (transform.forward * vertical + transform.right * horizontal).normalized;
            velocity = movementVector * speed; 
            if (!point)
            {
                Cammera();
            }
            //float vel = speed;
            //Vector3 dir = transform.forward.normalized * vel * inputMove.x + transform.right.normalized * vel * inputMove.z;
            //rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
            //rb.velocity = transform.forward.normalized * vel * inputMove.z + transform.right.normalized * vel * inputMove.x;
        }

        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
   

    public void Cammera()
    {
        //float mouseX = Input.GetAxis("Mouse X") * cinemachineFreeLook.m_XAxis.m_MaxSpeed * Time.deltaTime;
        //tranformPlayer.Rotate(Vector3.up * mouseX);
        Vector3 fwd=transform.position-cameraVirutal.position;
        fwd.y = 0;
        fwd.Normalize();
        transform.rotation=Quaternion.LookRotation(fwd);
    }


}
