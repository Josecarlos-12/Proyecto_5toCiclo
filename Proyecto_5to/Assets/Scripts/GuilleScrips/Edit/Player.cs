using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public LayerMask capaDelEnemigo;
    public float rangoDeAlerta;
    public CharacterController player;
    bool estarAlerta;
    public float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelEnemigo);

        if (estarAlerta == true)
        {
            playerSpeed = 5;
        }


        if (estarAlerta == false)
        {
            playerSpeed = 1;
        }
    }

    private void FixedUpdate()
    {
        player.Move(new Vector3(horizontalMove, 0, verticalMove) * playerSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
}
