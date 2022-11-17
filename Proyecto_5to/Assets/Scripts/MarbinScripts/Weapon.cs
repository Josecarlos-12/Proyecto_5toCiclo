using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool canShoot;
    public GameObject initialBullet, initialBullet2;
    public GameObject bulletFast, laserBullet;

    public float timeShoot = 0.2f;
    public float initialShoot;
    public Energy energy;
    public Shield shield;

    public Experience exp;

    [Header("Dos Balas")]
    public bool bDoubleBullet;
    public float time, maxTime;


    [Header("Chambiar Bala")]
    public bool chageBullet;
    public bool typeBullet;

    [Header("Bala SFX")]
    public AudioSource shootAudio;
    private void Update()
    {
        if(!typeBullet)
        Shoot();

        if(typeBullet)
        ShootLaser();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetButtonDown("Fire1") && Time.time > initialShoot && energy.use == false && shield.useShield == false && !exp.options)
            {
                if (energy.energy > 2)
                {
                    shootAudio.Play();
                    energy.ReductionEnergyShoot();
                    energy.recoverEnergy = true;
                    //energy.ReductionEnergy();
                    if (!bDoubleBullet)
                    {
                        Instantiate(bulletFast, initialBullet.transform.position, initialBullet.transform.rotation);
                    }
                    else if (bDoubleBullet)
                    {
                        Instantiate(bulletFast, initialBullet.transform.position, initialBullet.transform.rotation);
                        Instantiate(bulletFast, initialBullet2.transform.position, initialBullet2.transform.rotation);
                    }

                   
                    
                    //Instacie bulletPrefab en la posicion de initialBullet

                    
                    //Obtuve el rigibody para agragar fuerza
                    //Rigidbody rb = bulletTemporal.GetComponent<Rigidbody>();

                    // Agrege fuerza a la bala
                    //rb.AddForce(transform.forward * speedBullet);

                    // Destrui la bala
                    //Destroy(bulletTemporal, 0.5f);

                }

            }
        }
        
    }

    public void ShootLaser()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                chageBullet = !chageBullet;
            }
            if (Input.GetButtonDown("Fire1") && Time.time > initialShoot && energy.use == false && shield.useShield == false && !exp.options)
            {
                if (!chageBullet)
                {
                    shootAudio.Play();
                    if (!bDoubleBullet)
                    {
                        Instantiate(bulletFast, initialBullet.transform.position, initialBullet.transform.rotation);
                    }
                    else if (bDoubleBullet)
                    {
                        Instantiate(bulletFast, initialBullet.transform.position, initialBullet.transform.rotation);
                        Instantiate(bulletFast, initialBullet2.transform.position, initialBullet2.transform.rotation);
                    }
                    energy.recoverEnergy = true;
                    initialShoot = Time.time + timeShoot;                    
                }
                if (chageBullet)
                {
                    if (energy.energy > 100)
                    {
                        shootAudio.Play();
                        Instantiate(laserBullet, initialBullet.transform.position, initialBullet.transform.rotation);
                        energy.ReductionEnergyLaser();
                        energy.recoverEnergy = true;
                        initialShoot = Time.time + timeShoot;
                    }                       
                }
            }            
        }

    }
}

