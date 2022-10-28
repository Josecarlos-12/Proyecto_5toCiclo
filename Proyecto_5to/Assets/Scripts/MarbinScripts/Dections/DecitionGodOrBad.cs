using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecitionGodOrBad : MonoBehaviour
{
    public GameObject camaraDeath, prota, conteiner, camaraGod,camaraProta;
    public Rigidbody rb;
    public InteractuarJuny intera;
    public GameObject Juny;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (conteiner == null && !intera.god)
        {
            StartCoroutine(DeathDecition());
        }
        if (conteiner == null && intera.god)
        {
            StartCoroutine(GodDecition());
        }
    }

    public IEnumerator DeathDecition()
    {
        yield return new WaitForSeconds(4);
        prota.SetActive(true);
        camaraDeath.SetActive(false);
        Destroy(Juny);
    }

    public IEnumerator GodDecition()
    {
        yield return new WaitForSeconds(4);
        rb.isKinematic = false;
        camaraGod.SetActive(false);
        camaraProta.SetActive(true);
        Destroy(Juny);
    }
}
