using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ShootRobotin : MonoBehaviour
{
    bool Alert;
    public float AlertRange;
    public LayerMask playerMask;
    public GameObject player;

    public float initialShoot;
    public float timeShoot = 0.2f; 
    public GameObject Bullet;
    public Transform shotSpawn;
    public float bulletVelocity;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Point();
    }

    public void Point()
    {
        Alert = Physics.CheckSphere(transform.position, AlertRange, playerMask);
       
        if (Alert == true)
        {
            //Vector3 posJugador = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            Shoot();
        }

    }
    void Shoot()
    {
        if (Time.time > initialShoot)
        {
            Vector3 playerDirection = player.transform.position - transform.position;
            initialShoot = Time.time + timeShoot;
            GameObject bulletTemporal = Instantiate(Bullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
            Rigidbody rb = bulletTemporal.GetComponent<Rigidbody>();
            bulletTemporal.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);
            Destroy(bulletTemporal, 4);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, AlertRange);
    }
}
