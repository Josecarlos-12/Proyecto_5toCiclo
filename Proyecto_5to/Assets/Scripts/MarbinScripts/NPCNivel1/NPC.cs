using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject player, camara;
    public int count;
    public GameObject quiz;
    public SphereCollider circle;
    public Animator anim;
    public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count++;
            player.SetActive(false);
            circle.enabled = false;
            if (count == 1)
            {
                camara.SetActive(true);
                StartCoroutine(DialogueNPC());
            }
        }
    }

    public IEnumerator DialogueNPC()
    {
        yield return new WaitForSeconds(1.5f);
        text.text = "Ruee: Este nivel lo siento distinto al anterior, como si tuviera vida propia";
        yield return new WaitForSeconds(4);
        text.text = "Ruee: También siento peligro...";
        yield return new WaitForSeconds(4);
        text.text = "Ruee: ¿Crees que todo salga bien al final?";
        yield return new WaitForSeconds(2);
        quiz.SetActive(true);
        text.text = "";
    }

    public void God()
    {
        quiz.SetActive(false);
        player.SetActive(true);
        camara.SetActive(false);
        text.text = "Todo saldrá bien";
        StartCoroutine("MoveEnemy");
    }

    public void NoGod()
    {
        quiz.SetActive(false);
        player.SetActive(true);
        camara.SetActive(false);
        text.text = "No lo creo";
        StartCoroutine("MoveEnemy");
    }

    public IEnumerator MoveEnemy()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Move", true);
        yield return new WaitForSeconds(1);
        text.text = "";
        yield return new WaitForSeconds(5);
        Destroy(npc);
    }
}
