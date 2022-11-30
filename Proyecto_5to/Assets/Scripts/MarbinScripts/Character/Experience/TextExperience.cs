using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextExperience : MonoBehaviour
{
    public GameObject gText;
    public TextMeshProUGUI text; 
    public int count, count2, count3;
    [TextArea(4,4)]
    public string shield, otherBullet, wave;
    



    public void TextShield()
    {
        if (count < 3)
        {
            count++;
        }

        if (count == 1)
        {
            gText.SetActive(true);
            text.text= shield;
            StartCoroutine(DesactiveText());
        }       
    }

    public void OtherBullet()
    {
        if (count2 < 3)
        {
            count2++;
        }

        if (count2 == 1)
        {
            gText.SetActive(true);
            text.text = otherBullet;
            StartCoroutine(DesactiveText());
        }
    }

    public void Wave()
    {
        if (count3 < 3)
        {
            count3++;
        }

        if (count3 == 1)
        {
            gText.SetActive(true);
            text.text = wave;
            StartCoroutine(DesactiveText());
        }
    }


    public IEnumerator DesactiveText()
    {
        yield return new WaitForSeconds(3);
        gText.SetActive(false);
        count = 0;
        count2 = 0;
        count3 = 0;
    }
}
