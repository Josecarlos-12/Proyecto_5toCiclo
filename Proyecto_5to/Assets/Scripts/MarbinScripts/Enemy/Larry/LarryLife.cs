using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LarryLife : MonoBehaviour
{
    public Larry larry;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Bala");
            larry.render.material.color = Color.red;
            larry.life -= larry.bullet.damageB;
            StartCoroutine(larry.ChangeColor());
        }
        if (other.gameObject.CompareTag("LaserProta"))
        {
            larry.render.material.color = Color.red;
            larry.life -= larry.laser.damageB;
            StartCoroutine(larry.ChangeColor());
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            larry.render.material.color = Color.red;
            larry.life -= larry.sword.damage;
            Debug.Log("Macheteo");
            StartCoroutine(larry.ChangeColor());
        }
    }
}
