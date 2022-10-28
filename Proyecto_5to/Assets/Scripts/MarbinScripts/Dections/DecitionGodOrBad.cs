using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DecitionGodOrBad : MonoBehaviour
{
    public GameObject camaraDeath, prota, conteiner, camaraGod,camaraProta;
    public Rigidbody rb;
    public InteractuarJuny intera;
    public GameObject Juny;
    public TextMeshProUGUI text;
    public GameObject godDecition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (conteiner == null && !intera.god)
        {
            text.text = "Presentador: Hemos presentado algunos fallos, el jugador caído será transportado de nuevo al lobby";
            //text.color = Color.gray;
            StartCoroutine(DeathDecition());
        }
        if (conteiner == null && intera.god)
        {
            text.text = "Presentador: Hemos presentado algunos fallos, el jugador caído será transportado de nuevo al lobby";
            //text.color = Color.gray;
            StartCoroutine(GodDecition());
        }
    }

    public IEnumerator DeathDecition()
    {
        yield return new WaitForSeconds(5);
        prota.SetActive(true);
        camaraDeath.SetActive(false);
        Destroy(Juny);
        Destroy(text);
    }

    public IEnumerator GodDecition()
    {
        yield return new WaitForSeconds(4);
        godDecition.SetActive(false);
        rb.isKinematic = false;
        camaraGod.SetActive(false);
        camaraProta.SetActive(true);
        Destroy(Juny);
        Destroy(text);
    }
}
