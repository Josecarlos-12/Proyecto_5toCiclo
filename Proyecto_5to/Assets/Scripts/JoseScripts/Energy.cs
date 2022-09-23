using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [Header("Energy Amount")]
    [Range(0,100)]
    [SerializeField] private int energy = 100;
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       LessEnergy();
        AddEnergy();
    }

    public void AddEnergy()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer -= 1;
            if (energy < 100)
            {
                energy++;
            }
        }
        if(energy < 0)
        {
            energy = 0;
        }
    }

    public void ReductionEnergyJump()
    {
        energy -= 30;
    }

    public void ReductionEnergyShoot()
    {
        energy -= 2;
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
            energy = 100;
            Destroy(other.gameObject);
        }
    }
}
