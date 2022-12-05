using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialoguesNivel2a : MonoBehaviour
{
    public GameObject gText;
    public TextMeshProUGUI text;
    [TextArea(4, 4)]
    public string[] sTextt;
    public float[] time;


    private void Start()
    {
        StartCoroutine(Text());   
    }

    public IEnumerator Text()
    {
        yield return new WaitForSeconds(time[0]);
        text.text = sTextt[0];
        yield return new WaitForSeconds(time[1]);
        text.text = sTextt[1];
        yield return new WaitForSeconds(time[2]);
        gText.SetActive(false);
    }
}
