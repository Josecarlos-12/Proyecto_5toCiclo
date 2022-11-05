using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnObjects : MonoBehaviour
{

    public GameObject shoot, shootOne, shootThre;
    public GameObject laders, prota,cameraMain;
    public GameObject[] robots;
    public GameObject objects;
    public OnObjects on;
    public int count;

    public enum Shot
    {
        One,
        Two,
        three,
        four,
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
            case Shot.four:
                DestroyFour();
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

    public void DestroyFour()
    {
        if (shoot == null && shootOne == null && shootThre == null)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                laders.SetActive(true);
                cameraMain.SetActive(true);
                prota.SetActive(false);
                StartCoroutine(CameraFalse());
            }
            
        }
    }

    public IEnumerator CameraFalse()
    {
        yield return new WaitForSeconds(3);
        prota.SetActive(true);
        cameraMain.SetActive(false);
    }
}
