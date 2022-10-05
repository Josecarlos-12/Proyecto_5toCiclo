using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnObjects : MonoBehaviour
{

    public GameObject shoot, shootOne;
    public GameObject laders;
    public GameObject[] robots;

    public enum Shot
    {
        One,
        Two
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
}
