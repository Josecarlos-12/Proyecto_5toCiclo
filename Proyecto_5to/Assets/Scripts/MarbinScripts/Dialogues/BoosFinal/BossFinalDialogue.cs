using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class BossFinalDialogue : MonoBehaviour
{
    public GameObject gameText, cam, prota;
    [TextArea(4, 4)]
    public string[] stringText;
    public float[] time;
    public TextMeshProUGUI text;
    public NavMeshAgent agent;
    public Animator anim, aniCam;
    public BossFinalMArbin boss;
    public AudioSource audioBoss;
    public AudioClip clip, clipGame;

    [Header("Audio Vida Boss")]
    public AudioClip mildoscientos;
    public AudioClip ochocientos, cuatrocientos, cien, cienv2;
    public int count, count2, count3, count4;
    [TextArea(4,4)]
    public string[] stringLifeBoss;
    public float[] timeBoss;


    [Header("Audio Boss Final")]
    public BossFinalMArbin ma;
    public AudioClip NoGame;
    public float[] fina;
    [TextArea(4,4)]
    public string[] sFina;
    public bool des;
    public int counFinal;
    public GameObject cameraDeath;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dialogues());

    }

    private void Update()
    {
        LifeBoss();

        if (ma.death)
        {
            if (counFinal < 3)
                counFinal++;


            if (counFinal == 1)
            {
                StartCoroutine(AudioDeathFinal());
            }

        }
    }

    public IEnumerator Dialogues()
    {
        yield return new WaitForSeconds(time[0]);
        text.text = stringText[0];
        yield return new WaitForSeconds(time[1]);
        text.text = stringText[1];
        yield return new WaitForSeconds(time[2]);
        text.text = stringText[2];
        yield return new WaitForSeconds(time[3]);
        text.text = stringText[3];
        yield return new WaitForSeconds(time[4]);
        text.text = stringText[4];
        yield return new WaitForSeconds(time[5]);
        text.text = stringText[5];
        yield return new WaitForSeconds(time[6]);
        gameText.SetActive(false);
        aniCam.SetBool("Beck", true);
        //SegundaParte
        yield return new WaitForSeconds(time[7]);
        gameText.SetActive(true);
        audioBoss.Play();
        text.text = stringText[6];
        yield return new WaitForSeconds(time[8]);
        text.text = stringText[7];
        yield return new WaitForSeconds(time[9]);
        audioBoss.clip = clip;
        audioBoss.Play();
        //text.text = stringText[8];
        yield return new WaitForSeconds(time[10]);
        text.text = stringText[9];
        yield return new WaitForSeconds(time[11]);
        text.text = stringText[10];
        yield return new WaitForSeconds(time[12]);        
        cam.SetActive(false);
        prota.SetActive(true);
        anim.enabled = true;
        agent.enabled = true;
        boss.enabled = true;
        yield return new WaitForSeconds(time[13]);
        Debug.Log("Audio");
        audioBoss.clip = clipGame;
        audioBoss.Play();
        text.text = stringText[11];
        yield return new WaitForSeconds(time[14]);
        text.text = stringText[12];
        yield return new WaitForSeconds(time[15]);
        gameText.SetActive(false);
    }



    public void LifeBoss()
    {
        if (boss.life <= 1200)
        {
            if(count<3)
            count++;

            if (count == 1)
            {
                audioBoss.clip = mildoscientos;
                audioBoss.Play();
                StartCoroutine(MilDos());
            }
        }
        if (boss.life <= 800)
        {
            if (count2 < 3)
                count2++;

            if (count2 == 1)
            {
                StartCoroutine(Ochocientos());
                audioBoss.clip = ochocientos;
                audioBoss.Play();
            }
        }
        if (boss.life <= 600)
        {
            if (count3 < 3)
                count3++;

            if (count3 == 1)
            {
                StartCoroutine(CuatroCientos());
                audioBoss.clip = cuatrocientos;
                audioBoss.Play();
            }
        }
        if (boss.life <= 100)
        {
            if (count4 < 3)
                count4++;

            if (count4 == 1)
            {
                StartCoroutine(Cien());
                audioBoss.clip = cien;
                audioBoss.Play();
            }
        }
    }

    public IEnumerator MilDos()
    {
        yield return new WaitForSeconds(timeBoss[0]);        
        text.text = stringLifeBoss[0]; 
        gameText.SetActive(true);
        yield return new WaitForSeconds(timeBoss[1]);
        text.text = stringLifeBoss[1];
        yield return new WaitForSeconds(timeBoss[2]);
        gameText.SetActive(false);
    }

    public IEnumerator Ochocientos()
    {
        yield return new WaitForSeconds(timeBoss[3]);
        text.text = stringLifeBoss[2];
        gameText.SetActive(true);
        yield return new WaitForSeconds(timeBoss[4]);
        text.text = stringLifeBoss[3];
        yield return new WaitForSeconds(timeBoss[5]);
        gameText.SetActive(false);
    }

    public IEnumerator CuatroCientos()
    {
        yield return new WaitForSeconds(timeBoss[6]);
        text.text = stringLifeBoss[4];
        gameText.SetActive(true);
        yield return new WaitForSeconds(timeBoss[7]);
        text.text = stringLifeBoss[5];
        yield return new WaitForSeconds(timeBoss[8]);
        gameText.SetActive(false);
    }

    public IEnumerator Cien()
    {
        yield return new WaitForSeconds(timeBoss[9]);
        text.text = stringLifeBoss[6];
        gameText.SetActive(true);
        yield return new WaitForSeconds(timeBoss[10]);
        audioBoss.clip = cienv2;
        audioBoss.Play();
        text.text = stringLifeBoss[7];
        yield return new WaitForSeconds(timeBoss[11]);
        gameText.SetActive(false);
    }


    public IEnumerator AudioDeathFinal()
    {
        yield return new WaitForSeconds(fina[0]);
        prota.SetActive(false);
        cameraDeath.SetActive(true);
        audioBoss.clip = NoGame;
        audioBoss.Play();
        text.text = sFina[0];
        gameText.SetActive(true);
        yield return new WaitForSeconds(fina[1]);
        text.text = sFina[1];
        yield return new WaitForSeconds(fina[2]);
        text.text = sFina[2];
        yield return new WaitForSeconds(fina[3]);
        text.text = sFina[3];
        yield return new WaitForSeconds(fina[4]);
        des = true; prota.SetActive(true);
        cameraDeath.SetActive(false);
        gameText.SetActive(false);
    }
}
