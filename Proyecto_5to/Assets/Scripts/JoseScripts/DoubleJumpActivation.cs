using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpActivation : MonoBehaviour
{
    public Jump jump;

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Player") )
        {
            jump.jumpOne = false;
            jump.jumpTwo = true;
            Destroy(gameObject);
        }
    }

    public void DJump( )
    {
        jump.jumpOne = false;
        jump.jumpTwo = true;
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
