using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHabilities : MonoBehaviour
{
    public bool touch;

    public GameObject[] options;
    public bool dash;
    public bool jumpTrue;

    public enum habilities
    {
        DobleSalto_Dash,
        TiposDeBala,
        Escudo_Stats
    }
    public habilities hability;

    public Jump jump;

    public GameObject inte;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(touch && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
            switch (hability)
            {
                case habilities.DobleSalto_Dash:
                    options[0].SetActive(true);
                    break;
                    case habilities.TiposDeBala:
                    options[1].SetActive(true);
                    break;
                case habilities.Escudo_Stats:
                    options[2].SetActive(true);
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touch = false;
        }
    }

    public void DoubleJump()
    {
        Time.timeScale = 1;
        jumpTrue = true;
        options[0].SetActive(false);
        Destroy(inte);
    }

    public void Dash()
    {
        Time.timeScale = 1;
        dash = true;
        options[0].SetActive(false);
        Destroy(inte);
    }
}
