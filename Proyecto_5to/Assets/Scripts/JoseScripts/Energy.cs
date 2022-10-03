using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [Header("Energy Amount")]
    public float energy = 100;
    public float energyMax = 100;
    public int lessEnergy;
    public bool shoot;
    public bool laser;
    public bool dash;
    public bool jump;
    public Weapon weapon;
    public bool use;
    public bool recoverEnergy;
    public int count;
    public float timer;

    public Image image;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = energy / energyMax;
       LessEnergy();
        AddEnergy();
    }

    public void AddEnergy()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer -= 1;
            if (energy < energyMax)
            {
                energy+=3;
            }
        }
        if(energy < 0)
        {
            energy = 0;
        }
    }

    public void ReductionEnergyJump()
    {
        energy -= 10;
    }

    public void ReductionEnergyShoot()
    {
        energy -= 2;
    }

    public void ReductionEnergyDash()
    {
        energy -= 15;
    }

    public void LessEnergy()
    {
        if (energy <= 0)
        {
            use = true;
        }
        else
        {
            use = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Energy"))
        {
            energy = energyMax;
            Destroy(other.gameObject);
        }
    }
}
