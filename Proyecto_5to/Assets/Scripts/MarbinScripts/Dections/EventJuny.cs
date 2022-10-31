using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventJuny : MonoBehaviour
{
    public GameObject juny, prota,cameraJuny;
    public Collider box;
    public TextMeshProUGUI tex;
    public GameObject textObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            juny.SetActive(true);
            box.enabled = false;
            prota.SetActive(false);
            cameraJuny.SetActive(true);
            StartCoroutine(EventOne());
            textObject.SetActive(true);
            tex.text = "Juny:!Aaaaaaaaaaaaaaa!";
        }
    }

    public IEnumerator EventOne()
    {
        yield return new WaitForSeconds(6);
        cameraJuny.SetActive(false);
        prota.SetActive(true);
        tex.text = "Juny:!Ayuda!";
        yield return new WaitForSeconds(2);
        tex.text = "";
    }
}
