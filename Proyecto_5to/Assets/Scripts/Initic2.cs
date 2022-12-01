using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initic2 : MonoBehaviour
{
    public string nextLevel;

    public TextMeshProUGUI text;


    public float[] time;
    [TextArea(8, 8)]
    public string[] sDialogues;

    public int count;


    private void Update()
    {

        if (count < 3)
            count++;

        if (count == 1)
        {
            
            
        }
    }

    private void Start()
    {
        StartCoroutine(NextDialogueText2());
    }

    public IEnumerator NextDialogueText2()
    {
        yield return new WaitForSeconds(time[0]);
        Debug.Log("Entro");
        text.text = sDialogues[0];
        yield return new WaitForSeconds(time[1]);
        Debug.Log("Entro2");
        text.text = sDialogues[1];
        yield return new WaitForSeconds(time[2]);
        Debug.Log("Entro3");
        text.text = sDialogues[2];
        yield return new WaitForSeconds(time[3]);
        text.text = sDialogues[3];
        yield return new WaitForSeconds(time[4]);
        text.text = sDialogues[4];
        yield return new WaitForSeconds(time[5]);
        text.text = sDialogues[5];
        yield return new WaitForSeconds(time[6]);
        text.text = sDialogues[6];
        yield return new WaitForSeconds(time[7]);
        text.text = sDialogues[7];
        yield return new WaitForSeconds(time[8]);
        count = 0;
        SceneManager.LoadScene(nextLevel);
    }
}
