using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float AlertRange;
    public LayerMask capaDelJugador;
    public Transform player;
    bool Alert;
    public GameObject Bullet;
    public Transform shotSpawn;
    public float bulletVelocity;
    private float timer = 5f;
    [Header("Amount life")]
    [SerializeField] private int Life = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Alert = Physics.CheckSphere(transform.position, AlertRange, capaDelJugador);

        if (Alert==true)
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
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        timer -= Time.deltaTime;
        if (timer<=5)
        {
            Vector3 playerDirection = player.position - transform.position;
            GameObject newBullet;
            newBullet = Instantiate(Bullet, shotSpawn.position, shotSpawn.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);
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
