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
    public string[] dialoguesGod;
    public float[] timeGod;
    public string[] dialoguesBad;
    public float[] timeBad;
    public int count;
    void Update()
    {
        if (boss == null)
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
        gText.SetActive(true);
        text.text = dialoguesGod[0];
        yield return new WaitForSeconds(timeGod[1]);
        gText.SetActive(false);
        SceneManager.LoadScene("Credits");
    }

    public IEnumerator DecitionBad()
    {
        yield return new WaitForSeconds(timeBad[0]);
        gText.SetActive(true);
        text.text = dialoguesBad[0];
        yield return new WaitForSeconds(timeBad[1]);
        gText.SetActive(false);
        SceneManager.LoadScene("Credits");
    }
}
