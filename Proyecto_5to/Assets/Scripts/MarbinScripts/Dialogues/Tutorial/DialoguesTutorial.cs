using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class DialoguesTutorial : MonoBehaviour
{
    public AudioSource audi;
    public AudioClip acPro;
    public GameObject[] audioclip;
    public float[] time;
    public NewCamera cam;
    public Collider[] coll;
    public Transform point;
    public float rayDistance;
    public MoveRGB move;
    public GameObject cartel;

    [Header("Texto Dialogo")]
    public GameObject gText;
    public TextMeshProUGUI text;
    [TextArea(8,8)]
    public string[] dialogues;
    public float[] fTimeDialogues;

    private void Start()
    {
        StartCoroutine(Dialogue());
        StartCoroutine(TextDialogues());
    }

    public IEnumerator TextDialogues()
    {
        yield return new WaitForSeconds(fTimeDialogues[0]);
        text.text=dialogues[0]; 
        yield return new WaitForSeconds(fTimeDialogues[1]);
        text.text = dialogues[1];
        yield return new WaitForSeconds(fTimeDialogues[2]);
        text.text = dialogues[2];
        yield return new WaitForSeconds(fTimeDialogues[3]);
        text.text = dialogues[3];
        yield return new WaitForSeconds(fTimeDialogues[4]);
        gText.SetActive(false);
        text.text = dialogues[4];
    }


    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(point.position, point.forward, out hit, rayDistance))
        {
            if (hit.transform.name== "Left")
            {
                gText.SetActive(true);
                audioclip[0].SetActive(false);
                audioclip[1].SetActive(true);
                StartCoroutine(NextColl());
                StartCoroutine(NextRight());
            }
            else
            {

            }

        }
        if (Physics.Raycast(point.position, point.forward, out hit, rayDistance))
        {
            if (hit.transform.name == "Right")
            {
                gText.SetActive(true);
                text.text = dialogues[5];
                audi.clip = acPro;
                audi.Play();
                StartCoroutine(Move());
                audioclip[1].SetActive(false);
            }
            else
            {

            }

        }
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(point.position, point.forward * rayDistance);
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(time[0]);
        audioclip[0].SetActive(true);
        cam.moveCamera = true;
        yield return new WaitForSeconds(time[1]);
        coll[0].enabled = true;
    }

    public IEnumerator NextRight()
    {
        yield return null;
        text.text = dialogues[4];
        yield return new WaitForSeconds(fTimeDialogues[6]);
        gText.SetActive(false);
    }

    public IEnumerator NextColl()
    {
        yield return new WaitForSeconds(time[2]);
        coll[1].enabled = true;
    }
    public IEnumerator Move()
    {
        yield return new WaitForSeconds(time[3]);
        cartel.SetActive(true);
        yield return new WaitForSeconds(time[4]);
        move.move = true;         
        yield return new WaitForSeconds(time[5]);
        gText.SetActive(false);
        Destroy(gameObject);
    }
}
