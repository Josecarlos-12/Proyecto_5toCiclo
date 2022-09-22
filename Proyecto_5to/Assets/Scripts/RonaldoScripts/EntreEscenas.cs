using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreEscenas : MonoBehaviour
{
    private void Awake()
    {
        var noDestruirEscenas = FindObjectsOfType<EntreEscenas>();
        if(noDestruirEscenas.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    } 
}
