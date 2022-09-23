using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    public float jumpHeight=10;
    public bool grounded;

    //cantidad de saltos
    public int maxJumpCount=2;
    //cantidad de salto restantes
    public int jumpsRemaining=0;


    public Energy energy;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        //Obtener el componente rigidbody del objeto player
        rb = gameObject.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (energy.use)
        {
            maxJumpCount = 1;
        }
        else
        {
            maxJumpCount = 2;
        }
        //Una vez presionado espacio poder saltar
        if ((Input.GetKeyDown(KeyCode.Space))&&(jumpsRemaining>0))
        {
            
            rb.AddForce(Vector3.up*jumpHeight,ForceMode.Impulse);
            jumpsRemaining-=1; //Reducir 1 salto
        }

        if (jumpsRemaining <= 0)
        {
            count++;
            if (count == 1)
            {
                Debug.Log(jumpsRemaining);
                energy.jump = true;
                energy.ReductionEnergyJump();
                
            }
        }
           
        else
        {
            count = 0;
            energy.jump = false;
        }
    }

    public void OnCollisionEnter(Collision collision) 
    {
        //Si colisionamos con el suelo que sea =true
        if(collision.gameObject.tag=="Floor")
        {
            grounded=true;
            //Resetear la cantidad de saltos una vez colisione con el suelo
            jumpsRemaining=maxJumpCount;
        }
    }

     public void OnCollisionExit(Collision collision) 
    {
        //Si no colisionamos con el suelo que sea =false
        if(collision.gameObject.tag=="Floor")
        {
            grounded=false;
        }
    }
}
