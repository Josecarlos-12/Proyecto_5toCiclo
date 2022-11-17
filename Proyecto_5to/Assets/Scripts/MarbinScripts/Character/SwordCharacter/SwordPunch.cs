using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPunch : MonoBehaviour
{
    public Life life;
    public float choro=25;
    public bool stealLife;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (stealLife)
            {
                life.life += choro;
            }
        }
    }
}
