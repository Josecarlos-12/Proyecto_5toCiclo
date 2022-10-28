using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArañinColition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("LaserProta"))
        {
            Destroy(gameObject);
        }
    }
}
