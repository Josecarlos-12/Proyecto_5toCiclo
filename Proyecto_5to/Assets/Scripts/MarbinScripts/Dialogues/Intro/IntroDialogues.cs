using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroDialogues : MonoBehaviour
{
    public AudioSource asDialogue1;
    public AudioClip acDialogue2, acDialogue3;
    public string nextLevel;

    public TextMeshProUGUI text;


    public float[] time;
    [TextArea(8, 8)]
    public string[] sDialogues;

    public int count;


    private void Update()
    {
        if(count<3)
        count++;

        if (count == 1)
        {
           // asDialogue1 = GetComponent<AudioSource>();
            //asDialogue1.Play();
            //StartCoroutine(NexDialogueVoice());
            StartCoroutine(NextDialogueText());
        }
    }


    public IEnumerator NexDialogueVoice()
    {
        yield return new WaitForSeconds(8);
        asDialogue1.clip = acDialogue2;
        asDialogue1.Play();        
        yield return new WaitForSeconds(7);
        asDialogue1.clip = acDialogue3;
        asDialogue1.Play();        
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(nextLevel);
    }

    public IEnumerator NextDialogueText()
    {        
        yield return new WaitForSeconds(time[0]);
        text.text = sDialogues[0];
        yield return new WaitForSeconds(time[1]);
        text.text = sDialogues[1];
        yield return new WaitForSeconds(time[2]);
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
        SceneManager.LoadScene(nextLevel);
    }
}
