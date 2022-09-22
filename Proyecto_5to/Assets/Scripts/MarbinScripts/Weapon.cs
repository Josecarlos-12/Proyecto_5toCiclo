using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject initialBullet;
    public GameObject bulletPrefab;
    public float speedBullet = 500;

    public float timeShoot = 0.2f;
    public float initialShoot;
    public Energy energy;


    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > initialShoot)
        {
            energy.shoot = true;
            initialShoot = Time.time + timeShoot;

            //Instacie bulletPrefab en la posicion de initialBullet
            GameObject bulletTemporal = Instantiate(bulletPrefab, initialBullet.transform.position, initialBullet.transform.rotation) as GameObject;

            //Obtuve el rigibody para agragar fuerza
            Rigidbody rb = bulletTemporal.GetComponent<Rigidbody>();

            // Agrege fuerza a la bala
            rb.AddForce(transform.forward * speedBullet);

            // Destrui la bala
            Destroy(bulletTemporal, 2);
        }
        else
        {
            energy.shoot = false;
        }
    }
}
