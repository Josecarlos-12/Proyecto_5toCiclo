using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnGigant : MonoBehaviour
{
    public Transform prota;
    public Transform floor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gigant"))
        {
            prota.position=new Vector3(floor.position.x, floor.position.y+5, floor.position.z);
        }
    }
}
