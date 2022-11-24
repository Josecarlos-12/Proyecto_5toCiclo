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
    public int count, count1, count2, count3, count4, count5, count6, count7, count8, count9, count10, count11, count12, count13;
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


        if (robots[3] == null)
        {
            if (count3 < 3)
                count3++;

            if (count3 == 1)
                conteiner += 1;
        }


        if (robots[4] == null)
        {
            if (count4 < 3)
                count4++;

            if (count4 == 1)
                conteiner += 1;
        }


        if (robots[5] == null)
        {
            if (count5 < 3)
                count5++;

            if (count5 == 1)
                conteiner += 1;
        }


        if (robots[6] == null)
        {
            if (count6 < 3)
                count6++;

            if (count6 == 1)
                conteiner += 1;
        }


        if (robots[7] == null)
        {
            if (count7 < 3)
                count7++;

            if (count7 == 1)
                conteiner += 1;
        }

        if (robots[8] == null)
        {
            if (count8 < 3)
                count8++;

            if (count8 == 1)
                conteiner += 1;
        }

        if (robots[9] == null)
        {
            if (count9 < 3)
                count9++;

            if (count9 == 1)
                conteiner += 1;
        }

        /*if (robots[10] == null)
        {
            if (count10 < 3)
                count10++;

            if (count10 == 1)
                conteiner += 1;
        }

        if (robots[11] == null)
        {
            if (count11 < 3)
                count11++;

            if (count11 == 1)
                conteiner += 1;
        }

        if (robots[12] == null)
        {
            if (count12 < 3)
                count12++;

            if (count12 == 1)
                conteiner += 1;
        }

        if (robots[13] == null)
        {
            if (count13 < 3)
                count13++;

            if (count13 == 1)
                conteiner += 1;
        }*/
    }
}
