using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Right : MonoBehaviour
{
    public DialoguesTutorial dialogue;
    public GameObject raycast;
    public int count;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Raycas"))
        {
            if (count < 3)
                count++;

            if (count == 1)
            {
                Destroy(raycast);
                dialogue.r.enabled = false;
                dialogue.gText.SetActive(true);
                dialogue.text.text = dialogue.dialogues[5];
                dialogue.audi.clip = dialogue.acPro;
                dialogue.audi.Play();
                StartCoroutine(dialogue.Move());
                //dialogue.audioclip[1].SetActive(false);
                //dialogue.audioclip[0].SetActive(false);
            }
               
        }
    }
}
