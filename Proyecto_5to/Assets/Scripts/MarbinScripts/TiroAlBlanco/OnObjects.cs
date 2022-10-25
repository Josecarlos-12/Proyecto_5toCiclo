using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnObjects : MonoBehaviour
{

    public GameObject shoot, shootOne;
    public GameObject laders;
    public GameObject[] robots;
    public GameObject objects;
    public OnObjects on;

    public enum Shot
    {
        One,
        Two,
        three
    }
    public Shot shootDecition= Shot.Two;

    private void Update()
    {
        switch (shootDecition)
        {
            case Shot.One:
                DestroyOne();
                break;
            case Shot.Two:
                DestroyTwo();
                break;
            case Shot.three:
                DestroyThree();
                break;
        }

    }


    public void DestroyOne()
    {
        if (shoot == null)
        {
            laders.SetActive(true);
            for(int i = 0; i < robots.Length; i++)
            {
                robots[i].SetActive(true);
            }
        }
    }

    public void DestroyTwo()
    {
        if (shoot == null && shootOne == null)
        {
            laders.SetActive(true);
                for (int i = 0; i < robots.Length; i++)
                {
                    robots[i].SetActive(true);
                }


        }
    }

    public void DestroyThree()
    {
        if (shoot == null && shootOne == null)
        {
            laders.SetActive(true);

            if (objects != null)
            {
                objects.SetActive(true);
            }
        }
    }
}
