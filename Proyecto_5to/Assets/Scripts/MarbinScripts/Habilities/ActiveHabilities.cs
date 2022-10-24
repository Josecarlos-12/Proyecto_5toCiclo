using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveHabilities : MonoBehaviour
{
    public Jump jump;
    public DashController dash;
    public Weapon aim;
    public CameraView camAim;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DoubleJump")
        {
            jump.jumpTwo = true;
            jump.jumpOne = false;

        }
        if(other.gameObject.name == "Dash")
        {
            dash.canDash=true;
        }
        if (other.gameObject.name == "Aim")
        {
            aim.canShoot=true;
        }
    }
    
}
