using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Lifeshield : MonoBehaviour
{

    [Header("Amount life")]
    public float life = 100;
    public Sword sword;
    public Bullet bullet, laser;
    public Enemy3 enemy;



    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            enemy.life = false;
        }
    }

    public void OnTriggerEnter(Collider other)
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
