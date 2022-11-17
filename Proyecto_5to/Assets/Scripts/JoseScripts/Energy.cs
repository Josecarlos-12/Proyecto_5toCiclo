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
    public bool jump;
    public bool use;
    public bool recoverEnergy;
    public float timer;
    public float maxTimer=1;

    public Image image;
    public float lessDash = 150;
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
        if (timer >= maxTimer)
        {
            timer -= maxTimer;
            if (energy < energyMax)
            {
                energy+=25;
            }
        }
        if(energy < 0)
        {
            energy = 0;
        }
    }

    public void ReductionEnergyJump()
    {
        energy -= 150;
    }

    public void ReductionEnergyShoot()
    {
        //energy -= 2;
    }
    public void ReductionEnergyLaser()
    {
        energy -= 100;
    }
    public void ReductionEnergyDash()
    {
        energy -= lessDash;
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
