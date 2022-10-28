using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventJuny : MonoBehaviour
{
    public GameObject juny, prota,cameraJuny;
    public Collider box;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            juny.SetActive(true);
            box.enabled = false;
            prota.SetActive(false);
            cameraJuny.SetActive(true);
            StartCoroutine(EventOne());
        }
    }

    public IEnumerator EventOne()
    {
        yield return new WaitForSeconds(4);
        cameraJuny.SetActive(false);
        prota.SetActive(true);
            
    }
}
