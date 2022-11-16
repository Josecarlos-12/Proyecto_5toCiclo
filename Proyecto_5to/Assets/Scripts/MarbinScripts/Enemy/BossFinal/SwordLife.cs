using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLife : MonoBehaviour
{
    public GameObject sword;
    public bool bSword;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sword.SetActive(false);
            bSword = false;
        }
    }
}
