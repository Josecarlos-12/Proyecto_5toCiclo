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
        }
        else if (Input.GetKeyUp(KeyCode.E) || shieldLife.duration)
        {
            anim.SetBool("On", true);
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
    }
}
