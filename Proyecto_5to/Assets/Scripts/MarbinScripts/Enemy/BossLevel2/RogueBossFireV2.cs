using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBossFireV2 : MonoBehaviour
{
    public bool Active, active2;
    public int projectils, projectils2;
    public float FireTime = 2.5f, fireTime2=2.5f;
    public Transform PlayerPosition;

    public GameObject projectile, projectileBlue;


    int count, count2;
    float timer = 0, timer2=0;

    public float y;
    void Start()
    {
    }

    void Update()
    {
        if (Active)
            Fire();
        else
        {
            timer = 0;
        }

        if (active2)
        {
            Fire2();
        }
        else
        {
            timer2 = 0;
        }
    }

    void Fire()
    {

        timer += Time.deltaTime;
        if (timer > FireTime)
        {
            if (count >= projectils)
            {
                count = 0;
                //Active = false;
            }
            else
            {
                Instantiate(projectile, new Vector3(PlayerPosition.transform.position.x, y, PlayerPosition.transform.position.z), new Quaternion(0, 0, 0, 0));
                count++;
            }
            timer = 0;
        }
    }

    void Fire2()
    {

        timer2 += Time.deltaTime;
        if (timer2 > fireTime2)
        {
            if (count2 >= projectils2)
            {
                count2 = 0;
                //Active = false;
            }
            else
            {
                Instantiate(projectileBlue, new Vector3(PlayerPosition.transform.position.x, y, PlayerPosition.transform.position.z), new Quaternion(0, 0, 0, 0));
                count2++;
            }
            timer2 = 0;
        }
    }
}

