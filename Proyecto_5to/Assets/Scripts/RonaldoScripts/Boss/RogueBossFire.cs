using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBossFire : MonoBehaviour
{
    public bool Active;
    public int projectils;
    public float FireTime = 2.5f;
    public float RechargeTime = 6.2f;
    public Transform PlayerPosition;

    public GameObject projectile;

    bool Recharge = true;
    int count;
    float timer = 0;
    void Update()
    {
        if (Active)
            Fire();
        else
        {
            timer = 0;
        }

    }

    void Fire()
    {
        timer += Time.deltaTime;
        if (Recharge)
        {
            if (timer > FireTime)
            {
                Instantiate(projectile,new Vector3(PlayerPosition.transform.position.x, PlayerPosition.transform.position.y, PlayerPosition.transform.position.z),new Quaternion(0,0,0,0));
                count++;

                if(count >= projectils)
                {
                    Debug.Log("Recargar");
                    Recharge = false;
                    count = 0;
                }
                timer = 0;
            }
        }
        else
        {
            if(timer > RechargeTime)
            {
                timer = 0;
                Recharge = true;
            }
        }
    }
}
