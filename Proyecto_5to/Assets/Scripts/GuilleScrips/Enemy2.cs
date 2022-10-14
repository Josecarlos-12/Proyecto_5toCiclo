using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    [SerializeField] private int Life = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Alert = Physics.CheckSphere(transform.position, AlertRange, playerMask);

        if (Alert == true)
        {
            Vector3 posJugador = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            Shoot();
        }
        LifeDestroy();
    }

    public void LifeDestroy()
    {
        if (Life <= 0)
        {
            decition.transform.position = transform.position;
            decition.SetActive(true);
            Destroy(gameObject);
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
            Life--;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AlertRange);
    }

}
