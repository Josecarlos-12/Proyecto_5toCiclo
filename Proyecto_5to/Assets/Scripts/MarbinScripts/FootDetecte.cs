using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootDetecte : MonoBehaviour
{
    public Jump jump;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            jump.jump = true;
            jump.grounded = true;
            //Resetear la cantidad de saltos una vez colisione con el suelo
            jump.jumpsRemaining = jump.maxJumpCount;
            jump.jumpsRemainingTwo = jump.maxJumpCount;
        }
    }
}
