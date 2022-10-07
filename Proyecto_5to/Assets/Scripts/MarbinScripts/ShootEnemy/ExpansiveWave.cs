using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExpansiveWave : MonoBehaviour
{
    [Header("Recuperación")]
    public float life;
    public float maxlife;
    public Transform target;
    public Transform sure;
    public bool recuperation;
    public float time;
    public float maxTime;
    public int hits;


    [Header("Movimiento")]
    public Transform[] points;
    public NavMeshAgent agent;
    public int destPoint = 0;



    [Header("Onda Expansiva")]
    public float radius;
    public float forceExplotion;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        
    }

    void Update()
    {
        if (!recuperation)
        {
            if (agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }
        Recuperation();

        /*if (Input.GetKeyDown(KeyCode.Y))
        {
            Explotion();
            Debug.Log("Explosion");
        }*/

    }

    public void Recuperation()
    {
        if (hits>3)
        {            
            agent.destination = sure.position;
            if (agent.remainingDistance < 0.1)
            {
                time += Time.deltaTime;
                if (time >= maxTime)
                {
                    time -= maxTime;
                    if (life < maxlife)
                    {
                        life += 1;                        
                    }

                }
            }
            if (life == maxlife)
            {
                hits = 0;
            }
        }
    }

    public void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;       
    }

    public void Explotion()
    {
        Collider[] objects=Physics.OverlapSphere(transform.position, radius);

        foreach (Collider obj in objects)
        {
            Rigidbody rb2d=obj.GetComponent<Rigidbody>();
            if (rb2d != null)
            {
                Vector3 direction=obj.transform.position-transform.position;
                float distance = 0.3f + direction.magnitude;
                float forceInitial = forceExplotion / distance;
                rb2d.AddForce(direction * forceInitial);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            life--;
            hits++;
        }
    }
}
