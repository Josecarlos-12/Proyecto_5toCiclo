using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class MoveRGB : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    public Vector3 movementVector = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 velocity = Vector3.zero;

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 direction = (transform.forward * vertical + transform.right * horizontal).normalized;
            velocity = direction * speed;
            //float vel = speed;
            //Vector3 dir = transform.forward.normalized * vel * inputMove.x + transform.right.normalized * vel * inputMove.z;
            //rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
            //rb.velocity = transform.forward.normalized * vel * inputMove.z + transform.right.normalized * vel * inputMove.x;
        }

        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}
