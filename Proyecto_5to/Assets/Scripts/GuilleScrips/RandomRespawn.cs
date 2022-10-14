using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomRespawn : MonoBehaviour
{
    public GameObject Player;
    public Transform Pos1, Pos2, Pos3, Pos4;
    private int CantPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void respawn()
    {
        CantPos = Random.Range(1, 5);

        if (CantPos == 1)
        {
            Player.transform.position = Pos1.position;
        }

        if (CantPos == 2)
        {
            Player.transform.position = Pos2.position;
        }

        if (CantPos == 3)
        {
            Player.transform.position = Pos3.position;
        }

        if (CantPos == 4)
        {
            Player.transform.position = Pos4.position;
        }
    }
}
