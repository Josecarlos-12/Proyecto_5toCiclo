using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoFither : MonoBehaviour
{
    public GameObject sphere;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entro a la batalla");
            sphere.SetActive(true);
        }
    }
}
