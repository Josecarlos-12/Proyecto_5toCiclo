using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractuarJuny : MonoBehaviour
{
    public bool into, animTrue;

    public float time, maxTime;
    public Rigidbody rb;
    public Animator anim;
    public GameObject conteiner, juny, camaraDeath, prota;

    public GameObject camaraGod, camaraProta;
    public Rigidbody rbPlayer;
    public bool god;

    public TextMeshProUGUI text;
    public GameObject badDecition;
    public GameObject godDecition;
    private void Update()
    {
        //Timer();

        if(into && Input.GetKeyDown(KeyCode.E))
        {
            godDecition.SetActive(true);
            god = true;
            Destroy(conteiner);
            juny.SetActive(true);
            camaraGod.SetActive(true);
            camaraProta.SetActive(false);
            rbPlayer.isKinematic = true;
        }

        if (animTrue)
        {
            Timer();
        }
    }

    public void AminationTrue()
    {
        animTrue = true;
    }

    public void Timer()
    {        
        time+=Time.deltaTime;

        if(time >= maxTime)
        {
            rb.isKinematic = false;
            anim.enabled = false;
            StartCoroutine(Death());
            camaraDeath.SetActive(true);
            prota.SetActive(false);
            text.text = "Juni:¿Por qué me dejas caeeeeer?";
            badDecition.SetActive(true);
            StartCoroutine("Dialogue");
        }
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(2);
        badDecition.SetActive(false);
        text.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
        }
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        Destroy(conteiner); 
        juny.SetActive(true);
    }

   
}
