using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    RogueBossShield rgs;


    private void Start()
    {
        rgs = GameObject.FindGameObjectWithTag("Enemy").GetComponent<RogueBossShield>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destruido();
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            Destruido();
        }
    }
    void Destruido()
    {
        rgs.Shields_Actives += 1;
        Destroy(this.gameObject);
    }
}
