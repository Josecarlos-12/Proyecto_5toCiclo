using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class MoveRGB : MonoBehaviour
{
    public bool move;
    public float speed;
    public Rigidbody rb;
    public Head head;
    public bool crounch;
    public Jump jump;    

    [Header("Crouching")]
    public float initialSpeed;
    public float crawlSpeed;
    //public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;
    public bool canCrouch;

    //[Header("Keybinds")]
    //public KeyCode crouchKey=KeyCode.LeftControl;

    public Vector3 movementVector = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startYScale=transform.localScale.y;
        
        initialSpeed = speed;
        crawlSpeed = speed*0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Crouch();
    }

    public void Move()
    {
        if (move)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 velocity = Vector3.zero;

            if (horizontal != 0 || vertical != 0)
            {
                movementVector = (transform.forward * vertical + transform.right * horizontal).normalized;
                velocity = movementVector * speed;
                //float vel = speed;
                //Vector3 dir = transform.forward.normalized * vel * inputMove.x + transform.right.normalized * vel * inputMove.z;
                //rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
                //rb.velocity = transform.forward.normalized * vel * inputMove.z + transform.right.normalized * vel * inputMove.x;
            }

            
            /*if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                speed=crawlSpeed;
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                speed= initialSpeed;
            }*/

            velocity.y = rb.velocity.y;
            rb.velocity = velocity;
        }        
    }

    public void Crouch()
    {
        if (canCrouch)
        {
            //Te agachas
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                crounch = true;
                speed = crawlSpeed;
                transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
                rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            }

            //Dejas de agacharte
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                crounch = false;
                transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
                speed = initialSpeed;
            }
        }       
    }
}
