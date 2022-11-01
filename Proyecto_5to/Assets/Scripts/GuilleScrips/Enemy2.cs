using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    public GameObject decition;
    public float AlertRange;
    public LayerMask playerMask;
    public Transform player;
    bool Alert;
    public GameObject Bullet;
    public Transform shotSpawn;
    public float bulletVelocity;
    public float timeShoot = 0.2f;
    public float initialShoot;
    [Header("Amount life")]
    public float Life = 100;
    public float maxLife = 100;
    public Image lifeBar;

    public MiniBosWalk mini;
    public bool point;
    public SpawnerRobotines robotines;

    public Renderer enemy;

    public Sword sword;
    public Bullet bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeBar.fillAmount = Life / maxLife;
        Point();
        LifeDestroy();
        Atacks();
    }

    public void LifeDestroy()
    {
        if (Life <= 0)
        {
            if (decition!= null)
            {
                decition.transform.position = transform.position;
                decition.SetActive(true);
            }
            
            Destroy(gameObject);
        }
    }

    public void Point()
    {
        Alert = Physics.CheckSphere(transform.position, AlertRange, playerMask);

        if (point)
        {
            if (Alert == true)
            {
                Vector3 posJugador = new Vector3(player.position.x, transform.position.y, player.position.z);
                transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
                Shoot();
            }
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

        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(ChangeColor());
            enemy.material.color = Color.red;
            Life-=bullet.damageB;
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            enemy.material.color = Color.red;
            Life -= sword.damage;
            StartCoroutine(ChangeColor());
            Debug.Log("Macheteo");
        }
    }
    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        enemy.material.color = Color.white;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AlertRange);
    }


    public void Atacks()
    {
        if (Life < 700)
        {
            mini.charge = false;
            point = true;
        }
        if(Life < 600)
        {
            point = false;
            robotines.enabled = true;
        }
        if (Life < 200)
        {
            point = true;
        }
    }
}
