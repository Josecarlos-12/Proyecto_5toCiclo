using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFinal : MonoBehaviour
{
    public GameObject boss;
    public TextMeshProUGUI text;
    public GameObject gText;
    [TextArea(4,4)]
    public string[] dialoguesGod;
    public float[] timeGod;
    [TextArea(4, 4)]
    public string[] dialoguesBad;
    public float[] timeBad;
    public int count;

    public AudioSource audioGod, audioBad;

    public BossFinalDialogue BD;

    void Update()
    {
        if (BD.des)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                DeathBoss();
            }            
        }

    }


    public void DeathBoss()
    {
        if (PlayerPrefs.GetInt("BossDeath") != 0)
        {
            StartCoroutine(DecitionBad());
        }
        else
        {
            StartCoroutine(DecitionGod());
        }
    }

    public IEnumerator DecitionGod()
    {
        yield return new WaitForSeconds(timeGod[0]);
        audioGod.Play();
        gText.SetActive(true);
        text.text = dialoguesGod[0];
        yield return new WaitForSeconds(timeGod[1]);
        text.text = dialoguesGod[1];
        yield return new WaitForSeconds(timeGod[2]);
        text.text = dialoguesGod[2];
        yield return new WaitForSeconds(timeGod[3]);
        text.text = dialoguesGod[3];
        yield return new WaitForSeconds(timeGod[4]);
        text.text = dialoguesGod[4];
        yield return new WaitForSeconds(timeGod[5]);
        text.text = dialoguesGod[5];
        yield return new WaitForSeconds(timeGod[6]);
        text.text = dialoguesGod[6];
        yield return new WaitForSeconds(timeGod[7]);
        text.text = dialoguesGod[7];
        yield return new WaitForSeconds(timeGod[8]);
        gText.SetActive(false);
        SceneManager.LoadScene("Credits");
    }

    public IEnumerator DecitionBad()
    {
        yield return new WaitForSeconds(timeBad[0]);
        audioBad.Play();
        gText.SetActive(true);
        text.text = dialoguesBad[0];
        yield return new WaitForSeconds(timeBad[1]);
        text.text = dialoguesBad[1];
        yield return new WaitForSeconds(timeBad[2]);
        text.text = dialoguesBad[2];
        yield return new WaitForSeconds(timeBad[3]);
        text.text = dialoguesBad[3];
        yield return new WaitForSeconds(timeBad[4]);
        text.text = dialoguesBad[4];
        yield return new WaitForSeconds(timeBad[5]);
        text.text = dialoguesBad[5];
        yield return new WaitForSeconds(timeBad[6]);
        text.text = dialoguesBad[6];
        yield return new WaitForSeconds(timeBad[7]);
        text.text = dialoguesBad[7];
        yield return new WaitForSeconds(timeBad[8]);
        text.text = dialoguesBad[8];
        yield return new WaitForSeconds(timeBad[9]);
        SceneManager.LoadScene("Credits");
    }
}
