using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LifePena : MonoBehaviour
{
    public Pena pena;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            pena.render.material.color = Color.red;
            pena.life -= pena.bullet.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("LaserProta"))
        {
            pena.render.material.color = Color.red;
            pena.life -= pena.laser.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            pena.render.material.color = Color.red;
            pena.life -= pena.sword.damage;
            Debug.Log("Macheteo");
            StartCoroutine(ChangeColor());
        }

    }



    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        pena.render.material.color = Color.white;
    }
}
