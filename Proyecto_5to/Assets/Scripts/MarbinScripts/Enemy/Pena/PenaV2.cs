using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PenaV2 : MonoBehaviour
{
    [Header("Movimiento")]
    public Transform[] points;
    public float distancePoint;
    public NavMeshAgent agent;
    public int destPoint = 0;
    public float speedMin, speedMax;
    public Rigidbody rbEnemy;

    [Header("Seguimiento")]
    public GameObject player;
    public float detecte, detecteStop;
    public bool view, stop;

    [Header("Ataque")]
    public int count;
    public bool attack, touch;
    public Rigidbody rb;
    public MoveRGB move;
    public Life lifeProta;
    public GameObject col, col2;
    public bool bColl, funtionAll;

    [Header("Life")]
    public float life;
    public Sword sword;
    public Bullet bullet, laser;
    public Renderer render;
    public GameObject allContainer;


    //public LessLifeProta lessLife;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (funtionAll)
        {
            if (agent.remainingDistance < distancePoint && !view && !stop)
            {
                GotoNextPoint();
            }
            if (!stop)
            {
                Detectec();
            }

            DetectecStop();

        }
       
        Life();
    }

    public void Life()
    {
        if (life <= 0)
        {
            Destroy(allContainer);
        }
    }

    public void Detectec()
    {
        //Taclear       
        if (Vector3.Distance(transform.position, player.transform.position) < detecte)
        {
            agent.destination = player.transform.position;
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            view = true;
            if (!bColl)
            {
                col.SetActive(true);
                col2.SetActive(false);
            }
            
            agent.speed = 10;
            agent.acceleration = 14;
            //agent.angularSpeed = 500;
        }
        else
        {
            agent.speed = 4;
            agent.acceleration = 8;
            attack = false;
            view = false;
            col2.SetActive(false);
            col.SetActive(false);
            bColl = false;
        }
    }

    public void DetectecStop()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < detecteStop)
        {
            agent.destination = transform.position;
            agent.speed = 0;            
            stop = true;            
        }
        else
        {
            StartCoroutine(SpeedTimer());
        }
    }

    public IEnumerator SpeedTimer()
    {
        yield return new WaitForSeconds(2);
        stop = false;
    }

    public void GotoNextPoint()
    {
        Debug.Log("Caminando");
        if (points.Length == 0)
        {
            return;
        }
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detecte);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detecteStop);
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.name == "WaveProta")
        {
            if (count < 3)
            {
                count++;
            }
            if (count == 1)
            {
                Debug.Log("Toco Wave");
                funtionAll = false;
                StartCoroutine(ChangeColor());
                StartCoroutine(Empuje());
                life -= 60;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "WaveProta")
        {
            
        }
    }

    public IEnumerator Empuje()
    {
        yield return new WaitForSeconds(1);
        rbEnemy.constraints = ~RigidbodyConstraints.FreezeAll;
        StartCoroutine(TrueRotation());
    }

    public IEnumerator TrueRotation()
    {
        yield return new WaitForSeconds(1);
        funtionAll = true;
        count = 0;
        rbEnemy.constraints = RigidbodyConstraints.FreezeAll;
    }


    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        render.material.color = Color.white;
    }
}
