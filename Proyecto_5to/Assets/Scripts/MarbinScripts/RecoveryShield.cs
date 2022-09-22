using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryShield : MonoBehaviour
{
    public GameObject hexa1, hexa2, hexa3, hexa4, hexa5, hexa6, hexa7;
    public ShieldLife shieldLife;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldLife.one && !shieldLife.duration)
        {
            
            shieldLife.one = false;
            StartCoroutine(Hexa1());
        }
        if(shieldLife.two && !shieldLife.duration)
        {
            shieldLife.two = false;
            //StartCoroutine(Hexa2());
        }
        if (shieldLife.three && !shieldLife.duration)
        {
            shieldLife.three = false;
            //StartCoroutine(Hexa3());
        }
        if (shieldLife.four && !shieldLife.duration)
        {
            shieldLife.four = false;
            //StartCoroutine(Hexa4());
        }
        if (shieldLife.five && !shieldLife.duration)
        {
            shieldLife.five = false;
            //StartCoroutine(Hexa5());
        }
        if (shieldLife.six && !shieldLife.duration)
        {
            shieldLife.six = false;
            //StartCoroutine(Hexa6());
        }
    }

    public IEnumerator Hexa1()
    {
        yield return new WaitForSeconds(4);
        count++;
        if (count == 1)
        {
            shieldLife.lifeShield = shieldLife.lifeShield + 10;
        }        
        
    }


    public IEnumerator Hexa2()
    {
        yield return new WaitForSeconds(4);
        hexa2.SetActive(true);
        shieldLife.lifeShield += 10;
    }


    public IEnumerator Hexa3()
    {
        yield return new WaitForSeconds(4);
        hexa3.SetActive(true);
        shieldLife.lifeShield += 10;
    }

    public IEnumerator Hexa4()
    {
        yield return new WaitForSeconds(4);
        hexa4.SetActive(true);
        shieldLife.lifeShield += 10;
    }

    public IEnumerator Hexa5()
    {
        yield return new WaitForSeconds(4);
        hexa5.SetActive(true);
        shieldLife.lifeShield += 10;
    }

    public IEnumerator Hexa6()
    {
        yield return new WaitForSeconds(4);
        hexa6.SetActive(true);
        shieldLife.lifeShield += 10;
    }

    public IEnumerator Hexa7()
    {
        yield return new WaitForSeconds(4);
        hexa7.SetActive(true);
        shieldLife.lifeShield += 10;
    }
}
