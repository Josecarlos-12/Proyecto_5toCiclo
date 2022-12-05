using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.GlobalIllumination;
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
    public Bullet bullet, laser;
    public Collider cEnemy;

    [Header("Dialogos")]
    public GameObject cameraEnemy;
    public GameObject textContainer;
    public TextMeshProUGUI text;
    public float time;
    public OnObjects onObje;
    public int countEnemy;
    public Animator anim;
    public Collider mesh;
    public Transform ex1, ex2, ex3, ex4;
    public GameObject experiencia;
    public AudioSource audi, aShoot;
    [Header("Audio")]
    public AudioSource embestida;
    public AudioSource boss;
    public FadeMusic fade;

    void Start()
    {
        anim = GetComponent<Animator>();
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
            PlayerPrefs.SetInt("BossDeath", 1);
            if (decition!= null)
            {
                decition.transform.position = transform.position;
                decition.SetActive(true);
            }
            
            Destroy(gameObject);

            Instantiate(experiencia, transform.position, Quaternion.identity);
            Instantiate(experiencia, ex1.position, Quaternion.identity);
            Instantiate(experiencia, ex2.position, Quaternion.identity);
            Instantiate(experiencia, ex3.position, Quaternion.identity);
            Instantiate(experiencia, ex4.position, Quaternion.identity);
        }
    }
    public void EmbestidaAudio()
    {
        embestida.Play();
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
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            aShoot.Play();
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
        if (other.gameObject.CompareTag("LaserProta"))
        {
            enemy.material.color = Color.red;
            Life -= laser.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            enemy.material.color = Color.red;
            Life -= sword.damage;
            StartCoroutine(ChangeColor());
            Debug.Log("Macheteo");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(ChangeColor());
            enemy.material.color = Color.red;
            Life -= bullet.damageB;
        }
        if (collision.gameObject.CompareTag("LaserProta"))
        {
            enemy.material.color = Color.red;
            Life -= laser.damageB;
            StartCoroutine(ChangeColor());
        }
        if (collision.gameObject.CompareTag("Sword"))
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
            //mini.charge = false;
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
        if (Life < 100)
        {
            fade.touch = false;
            boss.volume -= 0.01f;

            point = false;
            robotines.enabled = false;
            mini.tackle = false;
            mini.charge = false;
            mini.canMove = false;
            cEnemy.isTrigger = false;
            mini.agent.enabled = false;
            
            if(countEnemy<3)
            countEnemy++;

            if (countEnemy == 1)
            {
                mesh.enabled = true;
                anim.SetBool("Death", true);
                textContainer.SetActive(true);
                audi.Play();
                text.text = "Det... Deten... Detente... por favor";
                cameraEnemy.SetActive(true);
                onObje.prota.SetActive(false);
                StartCoroutine(CameraFalse());
            }          

            
        }

    }

    public IEnumerator CameraFalse()
    {
        yield return new WaitForSeconds(5f);
        text.text = "No ves que sólo nos esta-mos de-fen-dien... do.";
        yield return new WaitForSeconds(5f);
        text.text = "¿Por qué siem-pre los hu-manos necesitan destruirlo todo?";
        yield return new WaitForSeconds(8f);
        textContainer.SetActive(false);
        cameraEnemy.SetActive(false);
        onObje.DestroyFour();        
    }
}
