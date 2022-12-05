using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public GameObject[] robots;
    public int count, count1, count2;
    public bool matoRobots, noMato;
    public OpenDoor door;
    public AudioSource audi;
    public Transform[] point;
    public GameObject exp;

    public GameObject dor;

    [TextArea(4,4)]
    public string[] text;
    public float[] fText;
    public GameObject gText;
    public TextMeshProUGUI textMesh;

    public enum Modulos
    {
        mod1, mod2, mod3, mod4
    }
    public Modulos mod;

    private void Update()
    {
        switch (mod)
        {
            case Modulos.mod1:
                DestroyOpen();
                break;
            case Modulos.mod2:
                Mod2();
            break;
            case Modulos.mod3:
                Mod3();
                break;
            case Modulos.mod4:
                Mod4();
                break;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (matoRobots)
            {
                if (count < 3)
                    count++;


                if (count == 1)
                {
                    if (audi != null)
                    {
                        audi.Play();
                        if (count2 < 3)
                            count2++;

                        if (count2 == 1)
                        {
                            StartCoroutine(DialogueCofe());
                        }
                    }


                }
            }



            if (noMato)
            {
                if (count1 < 3)
                    count1++;

                if (count1 == 1)
                {

                    if (audi != null)
                    {
                        audi.Play();
                        if (count2 < 3)
                            count2++;

                        if (count2 == 1)
                        {
                            StartCoroutine(DialogueCofe());
                        }
                    }

                    Instantiate(exp, point[0].transform.position, Quaternion.identity);
                    Instantiate(exp, point[1].transform.position, Quaternion.identity);
                    Instantiate(exp, point[2].transform.position, Quaternion.identity);
                    Instantiate(exp, point[3].transform.position, Quaternion.identity);
                    Instantiate(exp, point[4].transform.position, Quaternion.identity);
                    Instantiate(exp, point[5].transform.position, Quaternion.identity);
                    Instantiate(exp, point[6].transform.position, Quaternion.identity);
                    Instantiate(exp, point[7].transform.position, Quaternion.identity);
                    Instantiate(exp, point[8].transform.position, Quaternion.identity);
                    Instantiate(exp, point[9].transform.position, Quaternion.identity);

                    for (int i = 0; i < robots.Length; i++)
                    {
                        robots[i].SetActive(false);
                    }
                }
            }
        }
    }


    public void DestroyOpen()
    {
        if (dor == null)
        {
            Debug.Log(door.door);
            if (robots[0] == null || robots[1] == null || robots[2] == null || robots[3] == null || robots[4] == null
            || robots[5] == null || robots[6] == null || robots[7] == null || robots[8] == null || robots[9] == null || robots[10] == null || robots[11] == null)
            {
                matoRobots = true;
            }
            if (robots[0] != null && robots[1] != null && robots[2] != null && robots[3] != null && robots[4] != null
             && robots[5] != null && robots[6] != null && robots[7] != null && robots[8] != null && robots[9] != null && robots[10] != null && robots[11] != null)
            {
                noMato = true;
            }
        }
    }

    public void Mod2()
    {
        if (dor == null)
        {
            Debug.Log(door.door);
            if (robots[0] == null || robots[1] == null || robots[2] == null || robots[3] == null || robots[4] == null
            || robots[5] == null || robots[6] == null || robots[7] == null || robots[8] == null || robots[9] == null 
            || robots[10] == null || robots[11] == null || robots[12] == null || robots[13] == null)
            {
                matoRobots = true;
            }
            if (robots[0] != null && robots[1] != null && robots[2] != null && robots[3] != null && robots[4] != null
             && robots[5] != null && robots[6] != null && robots[7] != null && robots[8] != null && robots[9] != null 
             && robots[10] != null && robots[11] != null && robots[12] != null && robots[13] != null)
            {
                noMato = true;
            }
        }
    }

    public void Mod3()
    {
        if (dor == null)
        {
            Debug.Log(door.door);
            if (robots[0] == null || robots[1] == null || robots[2] == null || robots[3] == null || robots[4] == null
            || robots[5] == null || robots[6] == null || robots[7] == null || robots[8] == null || robots[9] == null
            || robots[10] == null || robots[11] == null || robots[12] == null || robots[13] == null || robots[14] == null
            || robots[15] == null || robots[16] == null)
            {
                matoRobots = true;
            }
            if (robots[0] != null && robots[1] != null && robots[2] != null && robots[3] != null && robots[4] != null
             && robots[5] != null && robots[6] != null && robots[7] != null && robots[8] != null && robots[9] != null
             && robots[10] != null && robots[11] != null && robots[12] != null && robots[13] != null && robots[14] != null
             && robots[15] != null && robots[16] != null)
            {
                noMato = true;
            }
        }

    }

    public void Mod4()
    {
        if (dor == null)
        {
            Debug.Log(door.door);
            if (robots[0] == null || robots[1] == null || robots[2] == null || robots[3] == null || robots[4] == null
            || robots[5] == null || robots[6] == null || robots[7] == null || robots[8] == null || robots[9] == null
            || robots[10] == null || robots[11] == null || robots[12] == null || robots[13] == null || robots[14] == null
            || robots[15] == null || robots[16] == null || robots[17] == null || robots[18] == null || robots[19] == null
            || robots[20] == null || robots[21] == null)
            {
                matoRobots = true;
            }
            if (robots[0] != null && robots[1] != null && robots[2] != null && robots[3] != null && robots[4] != null
             && robots[5] != null && robots[6] != null && robots[7] != null && robots[8] != null && robots[9] != null
             && robots[10] != null && robots[11] != null && robots[12] != null && robots[13] != null && robots[14] != null
             && robots[15] != null && robots[16] != null && robots[17] != null && robots[18] != null && robots[19] != null
             && robots[20] != null && robots[21] != null)
            {
                noMato = true;
            }
        }

    }

    public IEnumerator DialogueCofe()
    {
        yield return new WaitForSeconds(fText[0]);
        textMesh.text = text[0];
        gText.SetActive(true);
        yield return new WaitForSeconds(fText[1]);
        textMesh.text = text[1];
        yield return new WaitForSeconds(fText[2]);
        textMesh.text = text[2];
        yield return new WaitForSeconds(fText[3]);
        gText.SetActive(false);
    }
}
