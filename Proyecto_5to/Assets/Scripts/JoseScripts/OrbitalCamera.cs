using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 camOffset;

    //Rango de camara
    [Range(0.1f, 1.0f)]
    //suavidad de la camara
    public float SmoothFactor = 0.1f;

    public bool rotacionActive = true;
    public float velRotacion = 5.0f;

    //Deteccion de camara hacia el player
    public bool lookAtPlayer = false;


    // Start is called before the first frame update
    void Start()
    {
        //Una vez iniciado el juego camOffset sera igual a la posicion de la camara - la del player
        camOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotacionActive)
        {
            // camTurnAngle se usa para obtener el angulo de rotacion de la camara
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * velRotacion, Vector3.up);

            camOffset = camTurnAngle * camOffset;
        }

        //El newPos servira para obtener la nueva poscion del player
        Vector3 newPos = player.position + camOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        //Si rotacion es =true O lookAtPlayer =true la camara mirara hacia la direccion del player
        if(lookAtPlayer||rotacionActive)
        {
            transform.LookAt(player);
        }
    }
}
