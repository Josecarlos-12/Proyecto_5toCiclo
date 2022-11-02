using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DesactiveText : MonoBehaviour
{
    public bool into;
    public GameObject text;

    void Start()
    {
        
    }

    private void Update()
    {
        if (into)
        {
            StartCoroutine(Desactive());
        }
    }

    public IEnumerator Desactive()
    {
        yield return new WaitForSeconds(3);
        text.SetActive(false);
        into = false;
    }
}
