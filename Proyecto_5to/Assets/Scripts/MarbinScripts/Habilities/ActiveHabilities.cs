using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveHabilities : MonoBehaviour
{
    public Jump jump;
    public DashController dash;
    public Weapon aimA, aimB;
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
            aimA.canShoot=true;
            aimB.canShoot=true;
            camAim.aim=true;
        }
    }
    
}
