using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundsScript : MonoBehaviour
{
    public Collider coll;
    public AudioSource audiEnergy;
    public GameObject text;
    public TextMeshProUGUI textMesh;
    public float[] TimeText;
    [TextArea(4,4)]
    public string[] textString;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coll.enabled = false;
            audiEnergy.Play();
            StartCoroutine(DialogueText());            
        }
    }

    public IEnumerator DialogueText()
    {
        yield return new WaitForSeconds(TimeText[0]);
        text.SetActive(true);
        textMesh.text= textString[0];
        yield return new WaitForSeconds(TimeText[1]);
        textMesh.text = textString[1];
        yield return new WaitForSeconds(TimeText[2]);
        textMesh.text = textString[2]; 
        yield return new WaitForSeconds(TimeText[3]);
        textMesh.text = textString[3];
        yield return new WaitForSeconds(TimeText[4]);
        textMesh.text = textString[4];
        yield return new WaitForSeconds(TimeText[5]);
        textMesh.text = textString[5];
        yield return new WaitForSeconds(TimeText[6]);
        textMesh.text = textString[6];
        yield return new WaitForSeconds(TimeText[7]);
        textMesh.text = textString[7]; 
        yield return new WaitForSeconds(TimeText[8]);
        text.SetActive(false);
    }
}
