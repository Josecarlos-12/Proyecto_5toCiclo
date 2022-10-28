using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooting : MonoBehaviour
{
    public int life=4;

    private void Update()
    {
        Death();
    }

    public void Death()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("LaserProta"))
        {
            life--;
        }
    }
}
