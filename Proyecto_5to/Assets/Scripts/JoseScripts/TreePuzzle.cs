using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePuzzle : MonoBehaviour
{
    [Header("Collision")]
    public TreeCollision one,two,three,four;
    
    [Header("Trees")]
    public GameObject roble1;
    public GameObject roble2;
    public GameObject roble3;

    [Header("Box")]
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    [Header("FalseCollision")]
    public FalseCollision false1, false2, false3;


    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if ( one.bulletCollision )
        {
            roble1.SetActive(true);
            box1.SetActive(false);
        }

        if(one.bulletCollision && two.bulletCollision )
        {
            roble2.SetActive(true);
            box2.SetActive(false);
        }

        if ( one.bulletCollision && two.bulletCollision && three.bulletCollision)
        {
            roble3.SetActive(true);
            box3.SetActive(false);
        }
        if( one.bulletCollision && two.bulletCollision && three.bulletCollision && four.bulletCollision )
        {
            Debug.Log("Lo hiciste bien :DDDDDDDD");
        }
        
        if(false1.a >= 1 || false2.a >= 1 || false3.a >= 1 )
        {
            box1.SetActive(true);
            box2.SetActive(true);
            box3.SetActive(true);
            roble1.SetActive(false);
            roble2.SetActive(false);                            
            roble3.SetActive(false);
            one.bulletCollision = false;
            two.bulletCollision = false;
            three.bulletCollision = false;
            four.bulletCollision = false;
            false1.a = 0;
            false2.a = 0;
            false3.a = 0;
        }
    }
}
