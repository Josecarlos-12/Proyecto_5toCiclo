using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveMod1 : MonoBehaviour
{
    public GameObject robot1,robot2, bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(robot1 == null && robot2 == null)
        {
            Destroy(bar);
        }
    }
}
