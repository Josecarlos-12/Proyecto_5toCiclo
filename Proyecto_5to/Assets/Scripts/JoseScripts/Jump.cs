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
    public int countJump;

    public bool jump;

    public InteractionHabilities interaction;

    public int intera;

    // Start is called before the first frame update
    void Start()
    {
        //Obtener el componente rigidbody del objeto player
        rb = gameObject.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.jumpTrue)
        {
            if (countJump <= 3)
            {
                countJump++;
            }
            
            if (countJump == 1)
            {
                jumpsRemaining = 2;              
                
            }
            if (energy.energy > 10)
            {
                maxJumpCount = 2;
            }
            else
            {
                maxJumpCount = 1;
            }
        }

        if (maxJumpCount == 1)
        {
            intera = 1;
        }
        if (maxJumpCount == 2)
        {
            intera = 0;
        }
        //Una vez presionado espacio poder saltar
        if ((Input.GetKeyDown(KeyCode.Space))&&(jumpsRemaining>0))
        {
            
            rb.AddForce(Vector3.up*jumpHeight,ForceMode.Impulse);
            jumpsRemaining-=1; //Reducir 1 salto
        }

        if (jumpsRemaining <= intera)
        {
            count++;
            if (count == 1)
            {
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
            jump = true;
            grounded =true;
            //Resetear la cantidad de saltos una vez colisione con el suelo
            jumpsRemaining=maxJumpCount;
        }
    }

     public void OnCollisionExit(Collision collision) 
    {
        //Si no colisionamos con el suelo que sea =false
        if(collision.gameObject.tag=="Floor")
        {
            jump = false;
            grounded =false;
        }
    }
}
