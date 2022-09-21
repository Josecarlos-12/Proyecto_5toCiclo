using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ShieldLife : MonoBehaviour
{
    public int currentLife = 70;
    public int lifeShield = 70;
    public bool duration=false;

    public GameObject hexa1, hexa2, hexa3, hexa4, hexa5, hexa6, hexa7;

    private void Start()
    {
        duration = false;
    }

    private void Update()
    {
        LessLife();
    }

    public void Off()
    {
        this.gameObject.SetActive(false);
    }

    public void LessLife()
    {
        if (lifeShield < 70)
        {
            hexa1.SetActive(false);
        }
        if (lifeShield < 60)
        {
            hexa2.SetActive(false);
        }
        if (lifeShield < 50)
        {
            hexa3.SetActive(false);
        }
        if (lifeShield < 40)
        {
            hexa4.SetActive(false);
        }
        if (lifeShield < 30)
        {
            hexa5.SetActive(false);
        }
        if (lifeShield < 20)
        {
            hexa6.SetActive(false);
        }
        if (lifeShield <= 0)
        {
            duration = true;
        }
    }

  

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            lifeShield -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
}
