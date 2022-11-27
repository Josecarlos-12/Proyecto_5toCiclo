using MarwanZaky.MathfX;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RobotinIAMove : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRotation;


    public NavMeshAgent agent;
    public GameObject target;
    public Sword sword;
    public Bullet bullet, laser;
    public LayerMask playerMask;
    public float AlertRange;

    Vector3 origin = Vector3.zero; 
    Vector3 offset; 
    float startAngle;

    public float life=3;
    public GameObject robotin;

    public Renderer render;

    public GameObject experience;

    public int count;
    public Rigidbody rb;

    [Header("Musica")]
    public AudioSource audi;
    public AudioSource deathAudi, idle;
    public AudioClip death, detection, damage;
    public int countMusic;
    public bool bDeath, bIdle;
    public Animator anim;
    public float idleTime, idleTimeMax;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        /*GameObject[] tar = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject t in tar)
        {
            Destroy(t);
        }*/

        startPos = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        Life();

        IdleSound();

        if (robotin != null && !bDeath)
        {
            Destination();
        }
        
    }

    public void Life()
    {
        if (life <= 0)
        {
            if (countMusic < 3)
            {
                countMusic++;
            }

            if (countMusic == 1)
            {
                render.material.color = Color.red;
                anim.SetBool("Death", true);
                deathAudi.Play();
                bDeath = true;
                Instantiate(experience, transform.position, Quaternion.identity);
                Instantiate(experience, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.identity);
                Destroy(gameObject, 1);
            }
           
        }
    }

    private void Destination()
    {
        if (Physics.CheckSphere(transform.position, AlertRange, playerMask))
        {
            if (life > 0)
            {
                if (count < 3)
                {
                    count++;
                }

                if (count == 1)
                {
                    audi.volume = 1;
                    audi.clip = detection;
                    audi.Play();
                }
                bIdle = false;
                agent.destination = target.transform.position;
                agent.stoppingDistance = 4;
            }
        }
        else
        {
            bIdle = true;
            count = 0;
        }
    }

    public void IdleSound()
    {
        if (bIdle)
        {
            idleTime+=Time.deltaTime;

            if (idleTime >= idleTimeMax)
            {
                idleTime = 0;
                idle.Play();
            }
        }
        
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AlertRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!bDeath)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                audi.volume = 0.5f;
                audi.clip = damage;
                audi.Play();
                render.material.color = Color.red;
                life -= bullet.damageB;
                StartCoroutine(ChangeColor());
            }
            if (other.gameObject.CompareTag("LaserProta"))
            {
                audi.volume = 0.5f;
                audi.clip = damage;
                audi.Play();
                render.material.color = Color.red;
                life -= laser.damageB;
                StartCoroutine(ChangeColor());
            }
            if (other.gameObject.CompareTag("Sword"))
            {
                audi.volume = 0.5f;
                audi.clip = damage;
                audi.Play();
                render.material.color = Color.red;
                life -= sword.damage;
                Debug.Log("Macheteo");
                StartCoroutine(ChangeColor());
            }

            if (other.gameObject.name == "WaveProta")
            {
                if (count < 3)
                {
                    count++;
                }
                if (count == 1)
                {
                    audi.volume = 0.5f;
                    audi.clip = damage;
                    audi.Play();
                    StartCoroutine(ChangeColor());
                    StartCoroutine(Empuje());
                    life -= 60;
                }
            }

        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "WaveProta")
        {
            count = 0;
        }
    }

    public IEnumerator Empuje()
    {
        yield return new WaitForSeconds(1);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(TrueRotation());
    }

    public IEnumerator TrueRotation()
    {
        yield return new WaitForSeconds(1);
        rb.constraints = ~RigidbodyConstraints.FreezeAll;
    }

    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        render.material.color = Color.white;
    }
}
