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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       LessEnergy();
        if (energy < 100 && !shoot)
        {
            StartCoroutine(Recover());
        }
    }

    public IEnumerator Recover()
    {
        yield return new WaitForSeconds(5);
        if(energy <= 99)
        {
            energy += 1;
        }        
    }

    public void LessEnergy()
    {
        if (shoot)
        {
            energy -= 2;
        }
    }
}
