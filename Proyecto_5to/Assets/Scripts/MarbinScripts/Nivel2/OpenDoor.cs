using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{

    public Image image;
    public float maxConteiner = 120, conteiner, time, maxTime;
    public GameObject[] robots;
    public int count, count1, count2;
    public Animator anim;
    public GameObject doorContainer;


    public enum Open
    {
        uno,
        two
    }

    public Open open;

    void Update()
    {
        image.fillAmount = conteiner / maxConteiner;

        if (conteiner >= maxConteiner)
        {
            anim.SetBool("Open", true);
        }

        switch (open)
        {
            case Open.uno:
                TimeOpen();
            break;
            case Open.two:
                DestroyOpen();
            break;
        }
    }


    public void DestroyDoor()
    {
        Destroy(doorContainer);
    }

    public void TimeOpen()
    {
        time += Time.deltaTime;
        if (time >= maxTime)
        {
            time = 0;
            if(conteiner<=maxConteiner)
            conteiner += 1;
        }
    }

    public void DestroyOpen()
    {
        /*for (int i = 0; i < robots.Length; i++)
         {
             if (robots[i] == null)
             {
                 conteiner += 1;
             }
         }*/

        if (robots[0] == null)
        {
            if (count < 3)
                count++;

            if (count == 1)
                conteiner += 1;
        }

        if (robots[1] == null)
        {
            if(count1<3)
            count1++;

            if(count1==1)
            conteiner += 1;
        }       

        if (robots[2] == null)
        {
            if (count2 < 3)
                count2++;

            if (count2 == 1)
                conteiner += 1;
        }
    }
}
