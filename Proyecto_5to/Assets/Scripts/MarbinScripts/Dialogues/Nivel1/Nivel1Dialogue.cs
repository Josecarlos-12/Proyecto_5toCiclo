using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Nivel1Dialogue : MonoBehaviour
{
    public Collider coll;
    public AudioSource audi;
    public GameObject gText;
    public TextMeshProUGUI text;
    [TextArea(8,8)]
    public string[] sText;
    public float[] fTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coll.enabled = false;
            StartCoroutine(NextDialogue());
        }
    }

    public IEnumerator NextDialogue()
    {
        yield return new WaitForSeconds(fTime[0]);
        audi.Play();
        gText.SetActive(true);
        text.text = sText[0];
        yield return new WaitForSeconds(fTime[1]);
        text.text = sText[1];
        yield return new WaitForSeconds(fTime[2]);
        text.text = sText[2];
        yield return new WaitForSeconds(fTime[3]); 
        text.text = sText[3];
        yield return new WaitForSeconds(fTime[4]);
        gText.SetActive(false);
    }
}
