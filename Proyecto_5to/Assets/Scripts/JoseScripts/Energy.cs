using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [Header("Energy Amount")]
    [SerializeField] private int energy = 100;
    public int lessEnergy;
    public bool shoot;
    public bool laser;
    public bool dash;
    public Weapon weapon;
    public bool use;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       LessEnergy();
    }

    public IEnumerator Recover()
    {
        yield return new WaitForSeconds(5);
          
    }

    public void ReductionEnergy()
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
}
