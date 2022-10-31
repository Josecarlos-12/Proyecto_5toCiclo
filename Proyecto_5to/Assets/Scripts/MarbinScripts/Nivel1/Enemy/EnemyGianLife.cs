using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGianLife : MonoBehaviour
{
    public int life=150;


    void Update()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            life -= 20;
        }
    }
}
