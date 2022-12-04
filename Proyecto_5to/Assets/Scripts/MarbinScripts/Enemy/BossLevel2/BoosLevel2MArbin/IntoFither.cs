using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntoFither : MonoBehaviour
{
    public GameObject good;
    public GameObject textGame;
    public TextMeshProUGUI textMesh;
    public float[] time;
    [TextArea(4,4)]
    public string[] sText;
    public GameObject sphere, prota, cameraInit;
    public RogueBossFireV2 fire;
    //public 
    public AudioSource aud;
    public AudioClip D2;
    public Collider col;



    [Header("vida")]
    public LifeBossL2 life;
    public float[] floaLife;
    [TextArea(4,4)]
    public string[] sLife;
    public AudioClip mild, ochocientos, trescientos, derrota;
    public int count, count2, count3, count4, count5;


    private void Update()
    {
        if (life.HP <= 1200)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                StartCoroutine(MilDos());
            }

        }
        if (life.HP <= 800)
        {
            if (count2 < 3)
                count2++;

            if (count2 == 1)
            {
                StartCoroutine(Ochocientos());
            }

        }
        if (life.HP <= 300)
        {
            if (count3 < 3)
                count3++;

            if (count3 == 1)
            {
                StartCoroutine(Trescientos());
            }

        }
        if (life.HP <= 100)
        {
            if (count4 < 3)
                count4++;

            if (count4 == 1)
            {
                StartCoroutine(Derrota());
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
            Debug.Log("Entro a la batalla");
            prota.SetActive(false);
            cameraInit.SetActive(true);
            StartCoroutine(Dialogue());
        }
    }


    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(time[0]);
        aud.Play();
        textGame.SetActive(true);
        textMesh.text = sText[0];
        yield return new WaitForSeconds(time[1]);
        textMesh.text = sText[1];
        yield return new WaitForSeconds(time[2]);
        textGame.SetActive(false);
        prota.SetActive(true);
        cameraInit.SetActive(false);
        fire.Active = true;
        yield return new WaitForSeconds(time[3]);
        aud.clip = D2;
        aud.Play();
        textGame.SetActive(true);
        textMesh.text = sText[2];
        yield return new WaitForSeconds(time[4]);
        textGame.SetActive(false);
    }

    public IEnumerator MilDos()
    {
        yield return new WaitForSeconds(floaLife[0]);
        aud.clip = mild;
        aud.Play();
        textGame.SetActive(true);
        textMesh.text=sLife[0]; 
        yield return new WaitForSeconds(floaLife[1]);
        textMesh.text = sLife[1]; 
        yield return new WaitForSeconds(floaLife[2]);
        textGame.SetActive(false);
    }


    public IEnumerator Ochocientos()
    {
        yield return new WaitForSeconds(floaLife[3]);
        aud.clip = ochocientos;
        aud.Play();
        textGame.SetActive(true);
        textMesh.text = sLife[2];
        yield return new WaitForSeconds(floaLife[4]);
        textGame.SetActive(false);
    }

    public IEnumerator Trescientos()
    {
        yield return new WaitForSeconds(floaLife[5]);
        aud.clip = trescientos;
        aud.Play();
        textGame.SetActive(true);
        textMesh.text = sLife[3];
        yield return new WaitForSeconds(floaLife[6]);
        textMesh.text = sLife[4];
        yield return new WaitForSeconds(floaLife[7]);
        textGame.SetActive(false);
    }

    public IEnumerator Derrota()
    {
        yield return new WaitForSeconds(floaLife[8]);
        aud.clip = derrota;
        aud.Play();
        textGame.SetActive(true);
        textMesh.text = sLife[5];
        yield return new WaitForSeconds(floaLife[9]);
        textMesh.text = sLife[6];
        yield return new WaitForSeconds(floaLife[10]);
        textGame.SetActive(false);
        good.SetActive(true);
    }
}
