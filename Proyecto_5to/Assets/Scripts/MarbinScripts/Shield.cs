using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    public Animator anim;
    public ShieldLife shieldLife;
    public int Regeneration=4;
    public bool useShield;

    void Update()
    {

        ShieldOn();
        Duration();
    }

    public void ShieldOn()
    {
        if (Input.GetKeyDown(KeyCode.E) && !shieldLife.duration)
        {
            shield.SetActive(true);
            useShield = true;
        }
        else if (Input.GetKeyUp(KeyCode.E) || shieldLife.duration)
        {
            anim.SetBool("On", true);
            useShield = false;
        }
    }

    public void Duration()
    {
        if (shieldLife.duration)
        {
            StartCoroutine(OnShield());
        }
    }

    public IEnumerator OnShield()
    {
        yield return new WaitForSeconds(Regeneration);
        shieldLife.duration = false;
        shieldLife.lifeShield = shieldLife.currentLife;
        shieldLife.hexa1.SetActive(true);
        shieldLife.hexa2.SetActive(true);
        shieldLife.hexa3.SetActive(true);
        shieldLife.hexa4.SetActive(true);
        shieldLife.hexa5.SetActive(true);
        shieldLife.hexa6.SetActive(true);
    }
}
