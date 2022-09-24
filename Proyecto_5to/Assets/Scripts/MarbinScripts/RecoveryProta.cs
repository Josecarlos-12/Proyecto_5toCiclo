using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryProta : MonoBehaviour
{
    public GameObject[] prota;
    public int index;
    public Life life;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life.recorProta)
        {
            index = Random.Range(0, prota.Length);
            prota[index].SetActive(true);
            life = prota[index].GetComponentInChildren<Life>();
            //life = prota[index].GetComponent<Life>();
            life.recorProta = false;
        }
    }
}
