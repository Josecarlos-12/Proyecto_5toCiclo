using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamaraLoby : MonoBehaviour
{
    public GameObject prota, cam;

    // Start is called before the first frame update
    void Start()
    {
       prota.SetActive(false);
        cam.SetActive(true);
        StartCoroutine(ProtaTrue());
    }
 public IEnumerator ProtaTrue()
    {
        yield return new WaitForSeconds(5f);
        prota.SetActive(true);
        cam.SetActive(false);
    }
}
