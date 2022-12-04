using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobyText : MonoBehaviour
{
    public GameObject gameText;
    public TextMeshProUGUI meshText;
    public float[] fText;
    [TextArea(4,4)]
    public string[] sText;


    void Start()
    {
        StartCoroutine(Text());   
    }

    public IEnumerator Text()
    {
        yield return new WaitForSeconds(fText[0]);
        gameText.SetActive(true);
        meshText.text = sText[0];
        yield return new WaitForSeconds(fText[1]);
        meshText.text = sText[1]; 
        yield return new WaitForSeconds(fText[2]);
        meshText.text = sText[2];
        yield return new WaitForSeconds(fText[3]);
        meshText.text = sText[3];
        yield return new WaitForSeconds(fText[4]);
        gameText.SetActive(false);
    }
}
