using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGigant : MonoBehaviour
{
    public float life = 150; 

    private void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            life -= 5;
        }
        if (other.gameObject.CompareTag("BulletSlow"))
        {
            life -= 10;
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            life -= 50;
            Debug.Log("Macheteo");
        }
    }
}
