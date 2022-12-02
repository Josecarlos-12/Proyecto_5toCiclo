using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueLevel2 : MonoBehaviour
{
    public GameObject gameText, cam, prota;
    [TextArea(4,4)]
    public string[] stringText;
    public float[] time;
    public TextMeshProUGUI text;
    public int count;
    public AudioSource audi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          
            if (count<3)
            count++;

            if (count == 1)
            {
                Debug.Log("Dialogo");
                cam.SetActive(true);
                prota.SetActive(false);
                audi.Play();
                StartCoroutine(Dialogues());
            }
            
        }
    }


    public IEnumerator Dialogues()
    {
        yield return new WaitForSeconds(time[0]);
        text.text = stringText[0];
        gameText.SetActive(true);
        yield return new WaitForSeconds(time[1]);
        text.text = stringText[1];
        yield return new WaitForSeconds(time[2]);
        text.text = stringText[2];
        yield return new WaitForSeconds(time[3]);
        text.text = stringText[3];
        yield return new WaitForSeconds(time[4]);
        gameText.SetActive(false);
        cam.SetActive(false);
        prota.SetActive(true);
    }
}
