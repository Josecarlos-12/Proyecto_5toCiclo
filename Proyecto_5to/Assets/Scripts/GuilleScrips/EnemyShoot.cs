using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shotSpawn;
    public float bulletVelocity;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Shoot", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Vector3 playerDirection = player.position - transform.position;
        GameObject newBullet;
        newBullet = Instantiate(Bullet, shotSpawn.position, shotSpawn.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);
        Invoke("Shoot", 3);
    }
}
