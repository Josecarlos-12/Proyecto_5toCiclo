using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float caminar;
    public float agachado;
    float Speed;

    public KeyCode adelante;
    public KeyCode atras;
    public KeyCode izquierda; 
    public KeyCode derecha;


    public float hor;
    public float ver;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        KeyDetect();
        Move();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            Speed = agachado;

        else
            Speed = caminar;

        Vector3 velocity = Vector3.zero;

        if (hor != 0 || ver != 0)
        {
            Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;
            velocity = direction * Speed;
            direction.Normalize();
        }

        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }
    void KeyDetect()
    {
        if (Input.GetKey(adelante) && !Input.GetKey(atras))
            ver = 1;
        else if (Input.GetKey(atras) && !Input.GetKey(adelante))
            ver = -1;
        else
            ver = 0;

        if (Input.GetKey(derecha) && !Input.GetKey(izquierda))
            hor = 1;
        else if (Input.GetKey(izquierda) && !Input.GetKey(derecha))
            hor = -1;
        else
            hor = 0;
    }
}
