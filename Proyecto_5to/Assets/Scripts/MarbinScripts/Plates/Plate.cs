using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public GameObject obj;
    public int count;

    private void Update()
    {
        if (count > 0)
        {
            obj.SetActive(false);
        }
        if(count < 1)
        {
            obj.SetActive(true);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        count = count + 1;
    }

    private void OnCollisionExit(Collision collision)
    {
        count = count - 1;
    }

}
