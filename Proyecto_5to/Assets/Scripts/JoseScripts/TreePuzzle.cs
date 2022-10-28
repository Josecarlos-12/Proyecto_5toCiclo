using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

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

    public bool lTrueOne,ltrueTwo,lTrueThree,lTrueFour;
    public GameObject lO, lT, lTh, lF;

    public int count, countO, countT, countF;

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!lTrueOne)
        {
            countF++;
            if (countF == 1)
            {
                StartCoroutine("One");
            }            
        }
        if (lTrueOne)
        {
            StopCoroutine("One");
            count++;
            if (count == 1)
            {
                StartCoroutine("Two");
            }
            
        }
        if (ltrueTwo)
        {
            StopCoroutine("Two");
            countO++;
            if (countO == 1)
            {
                StartCoroutine("Three");
            }
        }
        if (lTrueThree)
        {
            StopCoroutine("Three");
            countT++;
            if (countT == 1)
            {
                StartCoroutine("Four");
            }
        }
        if (lTrueFour)
        {
            StopCoroutine("Four");
            lO.SetActive(false);
            lT.SetActive(false);
            lTh.SetActive(false);
            lF.SetActive(false);
        }


        if ( one.bulletCollision )
        {
            lTrueOne = true;
            roble1.SetActive(true);
            box1.SetActive(false);
        }

        if(one.bulletCollision && two.bulletCollision )
        {
            lTrueOne = false;
            ltrueTwo = true;
            roble2.SetActive(true);
            box2.SetActive(false);
        }

        if (one.bulletCollision && two.bulletCollision && three.bulletCollision)
        {
            ltrueTwo = false;
            lTrueThree = true;
            roble3.SetActive(true);
            box3.SetActive(false);
        }
        if( one.bulletCollision && two.bulletCollision && three.bulletCollision && four.bulletCollision )
        {
            lTrueThree = false;
            lTrueFour=true;
            if(enemy!=null)
            enemy.SetActive(true);
        }
        
        if(false1.a >= 1 || false2.a >= 1 || false3.a >= 1 )
        {
            lTrueOne = false;
            ltrueTwo = false;
            lTrueThree = false;
            count = 0;
            countO = 0;
            countT = 0;
            countF = 0;
            StopCoroutine("Two");
            StopCoroutine("Three");
            StopCoroutine("Four");


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

   public IEnumerator One()
    {
        yield return new WaitForSeconds(1);
        lO.SetActive(true);
        yield return new WaitForSeconds(1);
        lO.SetActive(false);
        yield return new WaitForSeconds(3);
        yield return One();
    }

    public IEnumerator Two()
    {
        yield return new WaitForSeconds(1);
        lO.SetActive(true);
        yield return new WaitForSeconds(1);
        lT.SetActive(true);
        yield return new WaitForSeconds(1);
        lO.SetActive(false);
        lT.SetActive(false);
        yield return new WaitForSeconds(3);
        yield return Two();
    }

    public IEnumerator Three()
    {
        yield return new WaitForSeconds(1);
        lO.SetActive(true);
        yield return new WaitForSeconds(1);
        lT.SetActive(true);
        yield return new WaitForSeconds(1);
        lTh.SetActive(true);
        yield return new WaitForSeconds(1);
        lO.SetActive(false);
        lT.SetActive(false);
        lTh.SetActive(false);
        yield return new WaitForSeconds(3);
        yield return Three();
    }

    public IEnumerator Four()
    {
        yield return new WaitForSeconds(1);
        lO.SetActive(true);
        yield return new WaitForSeconds(1);
        lT.SetActive(true);
        yield return new WaitForSeconds(1);
        lTh.SetActive(true);
        yield return new WaitForSeconds(1);
        lF.SetActive(true);
        yield return new WaitForSeconds(1);
        lO.SetActive(false);
        lT.SetActive(false);
        lTh.SetActive(false);
        lF.SetActive(false);
        yield return new WaitForSeconds(3);
        yield return Four();
    }
}
