using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ShieldBoss : MonoBehaviour
{
    public float life = 100;
    public GameObject shield;
    public Sword sword;
    public Bullet bullet, laser;
    public BossFinalMArbin boss;
    public int countShield;

    private void Update()
    {
        Life();
    }

    public void Life()
    {
        if (life <= 0)
        {
            if(countShield<3)
            countShield++;


            if (countShield == 1)
            {
                boss.bOnda = false;                
                shield.SetActive(false);
                life = 100;
                boss.bShield = false;
                boss.cProta.enabled = true; countShield = 0;
            }            
        }
    }

    public IEnumerator CountFalse()
    {
        yield return new WaitForSeconds(2);
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            life -= bullet.damageB;
        }
        if (other.gameObject.CompareTag("LaserProta"))
        {
            life -= laser.damageB;
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            life -= sword.damage;
        }
    }

}
