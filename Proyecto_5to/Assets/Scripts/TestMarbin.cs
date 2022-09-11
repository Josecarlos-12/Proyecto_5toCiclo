using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMarbin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.LogWarning("Marbbin es un CRACK");
        }
    }
}
