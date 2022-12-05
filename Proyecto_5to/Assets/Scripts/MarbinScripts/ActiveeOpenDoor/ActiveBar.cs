using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBar : MonoBehaviour
{
    public PlatformMovement move, move2, move3, move4, move5, move6, move7, move8, move9;
    public Animator anim;


    public void Anima()
    {
        anim.enabled = false;
    }

    public void PlatformSpped()
    {
        move.platformSpeed = 3;
    }

    public void PlatformSpped2()
    {
        move2.platformSpeed = 3;
    }

    public void PlatformSpped3()
    {
        move3.platformSpeed = 3;
    }

    public void PlatformSpped4()
    {
        move4.platformSpeed = 3;
    }

    public void PlatformSpped5()
    {
        move5.platformSpeed = 3;
    }

    public void PlatformSpped6()
    {
        move6.platformSpeed = 3;
    }

    public void PlatformSpped7()
    {
        move7.platformSpeed = 3;
    }

    public void PlatformSpped8()
    {
        move8.platformSpeed = 3;
    }

    public void PlatformSpped9()
    {
        move9.platformSpeed = 3;
    }
}
