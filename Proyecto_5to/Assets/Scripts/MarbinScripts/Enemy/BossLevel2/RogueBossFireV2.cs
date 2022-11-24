using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBossFireV2 : MonoBehaviour
{
    public bool Active;
    public int projectils;
    public float FireTime = 2.5f;
    public Transform PlayerPosition;

    public GameObject projectile;


    int count;
    float timer = 0;

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
}

