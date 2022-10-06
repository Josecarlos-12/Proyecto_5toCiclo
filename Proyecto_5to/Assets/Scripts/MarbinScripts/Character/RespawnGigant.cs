using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnGigant : MonoBehaviour
{
    public GameObject module;
    public Transform prota;
    public Transform floor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Module"))
        {
            module = other.gameObject;
        }
        if (other.gameObject.CompareTag("Gigant"))
        {
            prota.position=new Vector3(floor.position.x, floor.position.y+5, floor.position.z);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            prota.position=new Vector3(module.transform.position.x, module.transform.position.y+3, module.transform.position.z);
        }
    }
}
