using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Renderer render;
    public float AlertRange;
    public LayerMask capaDelJugador;
    public Transform player;
    bool Alert;
    public GameObject Bullet;
    public Transform shotSpawn;
    public float bulletVelocity; 
    public float timeShoot = 0.2f;
    public float initialShoot;
    [Header("Amount life")]
    public float Life = 100;
    public Sword sword;
    public Bullet bullet, laser;
    public GameObject experience;


    [Header("Sonido Robotin")]
    public AudioSource deathAudi;
    public int countMusic, countDetec;
    public AudioSource audi, damage, ADetec;        
    public Rigidbody rb;
    public bool bDeath;

    void Update()
    {
        Alert = Physics.CheckSphere(transform.position, AlertRange, capaDelJugador);

        if (Alert == true)
        {
            if (countDetec < 3)
            {
                countDetec++;
            }

            if (countDetec == 1)
            {
                ADetec.Play();
            }
            
            Vector3 posJugador = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            Shoot();
        }
        else
        {
            countDetec = 0;
        }
        LifeDestroy();
    }

    public void LifeDestroy()
    {
        if (Life <= 0)
        {
            if (countMusic < 3)
            {
                countMusic++;
            }

            if (countMusic == 1)
            {
                bDeath = true;
                rb.useGravity = true;
                deathAudi.Play();
                Destroy(gameObject,1);
                render.material.color = Color.red;
                Instantiate(experience, transform.position, Quaternion.identity);
                Instantiate(experience, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.identity);
            }

            
        }
    }

    void Shoot()
    {
        if (Time.time > initialShoot)
        {
            audi.Play();
            Vector3 playerDirection = player.position - transform.position;
            initialShoot = Time.time + timeShoot;
            GameObject bulletTemporal = Instantiate(Bullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
            Rigidbody rb = bulletTemporal.GetComponent<Rigidbody>();
            bulletTemporal.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);

        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (!bDeath)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                damage.Play();
                render.material.color = Color.red;
                Life -= bullet.damageB;
                StartCoroutine(ChangeColor());
            }
            if (other.gameObject.CompareTag("LaserProta"))
            {
                damage.Play();
                render.material.color = Color.red;
                Life -= laser.damageB;
                StartCoroutine(ChangeColor());
            }
            if (other.gameObject.CompareTag("Sword"))
            {
                damage.Play();
                render.material.color = Color.red;
                Life -= sword.damage;
                Debug.Log("Macheteo");
                StartCoroutine(ChangeColor());
            }
        }
            
    }

    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        render.material.color = Color.white;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AlertRange);
    }

}
