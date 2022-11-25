using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoFither : MonoBehaviour
{
    public GameObject sphere;
    public RogueBossFireV2 fire;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entro a la batalla");
            //sphere.SetActive(true);
            fire.Active = true;
        }
    }
}
