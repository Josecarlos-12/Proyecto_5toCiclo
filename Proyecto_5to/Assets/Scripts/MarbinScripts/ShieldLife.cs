using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ShieldLife : MonoBehaviour
{
    public int currentLife = 70;
    public int lifeShield = 70;
    public bool duration=false;
    public bool damage;

    public GameObject hexa1, hexa2, hexa3, hexa4, hexa5, hexa6, hexa7;
    public bool one, two, three, four, five, six;

    private void Start()
    {
        duration = false;
    }

    private void Update()
    {
        LessLife();
        MoreLife();
    }

    public void Off()
    {
        this.gameObject.SetActive(false);
    }

    public void LessLife()
    {
        if (lifeShield < 60)
        {
            one = true;
            hexa1.SetActive(false);
        }
        if (lifeShield < 50)
        {
            two = true;
            hexa2.SetActive(false);
        }
        if (lifeShield < 40)
        {
            three = true;
            hexa3.SetActive(false);
        }
        if (lifeShield < 30)
        {
            four = true;
            hexa4.SetActive(false);
        }
        if (lifeShield < 20)
        {
            five = true;
            hexa5.SetActive(false);
        }
        if (lifeShield < 10)
        {
            six = true;
            hexa6.SetActive(false);
        }
        if (lifeShield <= 0)
        {
            duration = true;
        }
    }
     
    public void MoreLife()
    {
        if (lifeShield > 60)
        {
            one = true;
            hexa1.SetActive(true);
        }
        if (lifeShield > 50)
        {
            two = true;
            hexa2.SetActive(true);
        }
        if (lifeShield > 40)
        {
            three = true;
            hexa3.SetActive(true);
        }
        if (lifeShield > 30)
        {
            four = true;
            hexa4.SetActive(true);
        }
        if (lifeShield > 20)
        {
            five = true;
            hexa5.SetActive(true);
        }
        if (lifeShield > 10)
        {
            six = true;
            hexa6.SetActive(true);
        }
    }
  

    private void OnTriggerEnter(Collider other)
    {

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            lifeShield -= 1;
            damage = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            damage = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }
}
