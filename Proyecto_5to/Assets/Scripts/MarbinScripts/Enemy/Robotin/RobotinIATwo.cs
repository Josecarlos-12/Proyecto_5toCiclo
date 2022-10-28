using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class RobotinIATwo : MonoBehaviour
{

    Vector3 startPos;
    Quaternion startRotation;


    public NavMeshAgent agent;
    public GameObject target;
    public LayerMask playerMask;
    public float AlertRange;

    Vector3 origin = Vector3.zero;
    Vector3 offset;
    float startAngle;

    public float life = 3;
    public GameObject robotin;
    public bool CanMove;

    public ShootRobotin shoot;
    public GameObject girl;

    public GameObject cinematica;
    public GameObject cameraEnemy;
    public int count;

    public GameObject decitionBad;

    [Header("Enemy")]
    public Collider circle;
    public MeshFilter render;
    public ShootRobotin shotEnemy;
    public Rigidbody rb;
    public GameObject allDecition;

    public GirlGod gir;
    public GameObject godDecition;
    public int CountT;

    public GameObject camaraBad, camaraGod;
    public Transform girBad;
    public Animator girAnim;
    public GameObject enemyFiveLife;
    public enum LifeDecition
    {
        cinematica,
        lifeDec
    }

    public LifeDecition lifedecition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        startPos = transform.position;
        startRotation = transform.rotation;
    }



    private void Update()
    {
        LessLife5();
        Life();
        if (robotin != null)
        {
            Destination();
        }

    }


    public void Life()
    {

        switch (lifedecition)
        {
            case LifeDecition.cinematica:
                if (life <= 0)
                {
                    CountT++;
                    circle.enabled = false;
                    render.mesh = null;
                    shotEnemy.enabled = false;
                    agent.enabled = false;
                    rb.isKinematic = true;
                    godDecition.SetActive(true);
                    girl.SetActive(false);
                    target.SetActive(false);
                    StartCoroutine("OnDecitionGod");
                    StopCoroutine("DecitionBad");
                }
                break;
                case LifeDecition.lifeDec:
                if (life <= 0)
                {
                    Destroy(allDecition);
                }
                break;
        }
        
       
    }


    public IEnumerator OnDecitionGod()
    {
        yield return new WaitForSeconds(5);
        //godDecition.SetActive(false);
        target.SetActive(true);
        Destroy(allDecition);
    }


    private void Destination()
    {
        if (!CanMove)
        {
            if (Physics.CheckSphere(transform.position, AlertRange, playerMask))
            {
                agent.destination = target.transform.position;
                agent.stoppingDistance = 6;
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
        if (other.gameObject.CompareTag("Bullet"))
        {
            life--;
        }
    }

    public void LessLife5()
    {
        if (life <= 5)
        {
            CanMove = true;
            shoot.canShoot = true;

            count++;

            if(count == 1)
            {
                girl.SetActive(true);
                cinematica.SetActive(true);
                target.SetActive(false);
                StartCoroutine(Enemy());
            }
            
            
        }
    }

    public IEnumerator Enemy()
    {
        yield return new WaitForSeconds(5);
        cinematica.SetActive(false);
        cameraEnemy.SetActive(true);

        yield return new WaitForSeconds(3);
        cameraEnemy.SetActive(false);
        target.SetActive(true);
        StartCoroutine("DecitionBad");
    }

    public IEnumerator DecitionBad()
    {
        yield return new WaitForSeconds(5);
        circle.enabled = false;
        render.mesh = null;
        shotEnemy.enabled = false;
        agent.enabled = false;
        rb.isKinematic = true;
        girl.SetActive(false);
        target.SetActive(false);
        decitionBad.SetActive(true);
        StartCoroutine("OnDecitionBad");
    }

    public IEnumerator OnDecitionBad()
    {
        yield return new WaitForSeconds(3);
        target.SetActive(true);
        decitionBad.SetActive(false);
        girBad.SetParent(null);
        girAnim.enabled = false;
        girBad.transform.position = transform.position;
        enemyFiveLife.SetActive(true);
        Destroy(allDecition);

    }
}
