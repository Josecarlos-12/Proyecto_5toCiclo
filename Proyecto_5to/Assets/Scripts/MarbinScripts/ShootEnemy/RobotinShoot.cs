using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotinShoot : MonoBehaviour
{
    public float initialShoot;
    //public Transform player;
    public float timeShoot = 0.2f;
    public Transform shotSpawn;
    //public float bulletVelocity;
    public GameObject Bullet;
    public AudioSource audi;
    public EnemyGianLife enemy;

    private void Update()
    {
        if(!enemy.bDeath)
        Shoot();
    }

    void Shoot()
    {
        if (Time.time > initialShoot)
        {
            audi.Play();
            //Vector3 playerDirection = player.position - transform.position;
            initialShoot = Time.time + timeShoot;
            Instantiate(Bullet, shotSpawn.transform.position, shotSpawn.transform.rotation);
            //Rigidbody rb = bulletTemporal.GetComponent<Rigidbody>();
            //bulletTemporal.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);

        }
    }
}
