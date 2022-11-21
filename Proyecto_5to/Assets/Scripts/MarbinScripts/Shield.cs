using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public bool canShild;
    public GameObject shield;
    public Animator anim;
    public ShieldLife shieldLife;
    public int Regeneration=4;
    public bool useShield;
    public float timer;

    [Header("Shield SFX")]
    public AudioSource shieldAudio;


    [Header("Imagen Escudo")]
    public Color shieldInitial;
    public Image shieldImage;

    public KeyCode kSh = KeyCode.C;

    void Update()
    {
        AddLife();
        ShieldOn();
        Duration();
    }

    public void ShieldOn()
    {
        if (canShild)
        {
            if (Input.GetKeyDown(kSh) && !shieldLife.duration)
            {
                shieldImage.color = Color.white;
                shieldAudio.Play();
                shield.SetActive(true);
                useShield = true;
            }
            else if (Input.GetKeyUp(kSh) || shieldLife.duration)
            {
                shieldImage.color = shieldInitial;
                anim.SetBool("On", true);
                useShield = false;
            }
        }        
    }

    public void AddLife()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer -= 1;
            if (shieldLife.lifeShield < 35)
            {
                shieldLife.lifeShield++;
            }
        }
        if (shieldLife.lifeShield < 0)
        {
            shieldLife.lifeShield = 0;
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
