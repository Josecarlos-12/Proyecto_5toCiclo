using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public float caminar;
    public float agachado;
    float Speed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {

        Move();

    }
    void Move()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            Speed = agachado;

        else
            Speed = caminar;

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;

        if (hor != 0 || ver != 0)
        {
            Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;

            velocity = direction * Speed;
        }

        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }
}
