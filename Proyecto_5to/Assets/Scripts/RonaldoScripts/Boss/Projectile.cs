using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage;
    public GameObject esto;
    public bool damageRecibe = false;
    GameObject Player;

    public void Impact()
    {
        if (damageRecibe) {
            Debug.Log("daño recibido");
            Destroy(esto);
        }
        else
        {
            Destroy(esto);
            Debug.Log("Explosion");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player = other.GetComponent<GameObject>();
            damageRecibe = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            damageRecibe = false;
        }
    }
}
