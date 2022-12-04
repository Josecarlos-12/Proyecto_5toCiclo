using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using TMPro;

public class Enemy3 : MonoBehaviour
{
    public GameObject Shield;
    public float timeShield = 0.2f;
    public float initialShield;
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
    public bool life;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Alert = Physics.CheckSphere(transform.position, AlertRange, capaDelJugador);

        if (Alert == true)
        {
            Vector3 posJugador = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            Shoot();
            Atacks();
        }
        LifeDestroy();
    }

    public void LifeDestroy()
    {
        if (Life <= 0)
        {
            Destroy(gameObject);
            Instantiate(experience, transform.position, Quaternion.identity);
            Instantiate(experience, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }

    void Shoot()
    {
        if (Time.time > initialShoot)
        {
            Vector3 playerDirection = player.position - transform.position;
            initialShoot = Time.time + timeShoot;
            GameObject bulletTemporal = Instantiate(Bullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
            Rigidbody rb = bulletTemporal.GetComponent<Rigidbody>();
            bulletTemporal.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);
            //Shield.SetActive(false);


        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (!life)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                render.material.color = Color.red;
                Life -= bullet.damageB;
                StartCoroutine(ChangeColor());
            }
            if (other.gameObject.CompareTag("LaserProta"))
            {
                render.material.color = Color.red;
                Life -= laser.damageB;
                StartCoroutine(ChangeColor());
            }
            if (other.gameObject.CompareTag("Sword"))
            {
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

    public void Atacks()
    {
        if (Life <= 100)
        {
            if (Shield != null)
            {
                Shield.SetActive(true);
                life = true;
            }
            
        }
       

    }

    void ShieldTime()
    {
        if (Time.time > initialShield)
        {

            initialShield = Time.time + timeShield;
            Shield.SetActive(false);


        }
        else
        {
            Atacks();
        }

    }

}
