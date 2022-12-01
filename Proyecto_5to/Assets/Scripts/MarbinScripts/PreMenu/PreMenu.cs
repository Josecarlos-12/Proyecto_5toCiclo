using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreMenu : MonoBehaviour
{
    public float[] time;
    [TextArea(4,4)]
    public string[] text;
    public TextMeshProUGUI textMes;

    private void Start()
    {
        PlayerPrefs.SetInt("PreIntro", 0);
        StartCoroutine(Text());   
    }

    public IEnumerator Text()
    {
        yield return new WaitForSeconds(time[0]);
        textMes.text = text[0];
        yield return new WaitForSeconds(time[1]);
        textMes.text = text[1];
        yield return new WaitForSeconds(time[2]);
        SceneManager.LoadScene("MainMenu");
    }
}
