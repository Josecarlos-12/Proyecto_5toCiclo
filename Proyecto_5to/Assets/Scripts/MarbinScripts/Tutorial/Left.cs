using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public DialoguesTutorial dialogue;
    public int count;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Raycas"))
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                Debug.Log("Left");
                dialogue.gText.SetActive(true);
                dialogue.l.Stop();
                //dialogue.audioclip[0].SetActive(false);
                dialogue.audioclip[1].SetActive(true);
                StartCoroutine(dialogue.NextColl());
                StartCoroutine(dialogue.NextRight());
                dialogue.l.Stop();
            }
            
        }
    }
}
