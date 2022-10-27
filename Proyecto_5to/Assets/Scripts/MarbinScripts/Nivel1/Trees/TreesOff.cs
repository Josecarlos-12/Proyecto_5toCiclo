using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesOff : MonoBehaviour
{
    public GameObject[] dianas;

    public GameObject laser, laserTwo, laserAll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dianas[0] == null)
        {
            Destroy(laser);
        }
        if(dianas[1] == null)
        {
            Destroy(laserTwo);
        }
        if (dianas[0] == null && dianas[2] == null && dianas[1] == null)
        {
            Destroy(laserAll);
        }
    }
}
