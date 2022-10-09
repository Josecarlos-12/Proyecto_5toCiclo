using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool canShoot;
    public GameObject initialBullet;
    public GameObject bulletFast;
    public GameObject bulletSlow;
    public InteractionHabilities interactions;

    public float timeShoot = 0.2f;
    public float initialShoot;
    public Energy energy;
    public Shield shield;
    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetButtonDown("Fire1") && Time.time > initialShoot && energy.use == false && shield.useShield == false && interactions.shootFast)
            {
                if (energy.energy > 2)
                {
                    energy.ReductionEnergyShoot();
                    energy.recoverEnergy = true;
                    //energy.ReductionEnergy();
                    initialShoot = Time.time + timeShoot;

                    //Instacie bulletPrefab en la posicion de initialBullet

                    Instantiate(bulletFast, initialBullet.transform.position, initialBullet.transform.rotation);


                    //Obtuve el rigibody para agragar fuerza
                    //Rigidbody rb = bulletTemporal.GetComponent<Rigidbody>();

                    // Agrege fuerza a la bala
                    //rb.AddForce(transform.forward * speedBullet);

                    // Destrui la bala
                    //Destroy(bulletTemporal, 0.5f);

                }

            }
            if (Input.GetButtonDown("Fire1") && Time.time > initialShoot && energy.use == false && shield.useShield == false && interactions.shootSlow)
            {
                if (energy.energy > 3)
                {
                    energy.ReductionEnergyShoot();
                    energy.recoverEnergy = true;
                    //energy.ReductionEnergy();
                    initialShoot = Time.time + timeShoot;

                    //Instacie bulletPrefab en la posicion de initialBullet

                    Instantiate(bulletSlow, initialBullet.transform.position, initialBullet.transform.rotation);
                }
            }
        }
        
    } 
}

