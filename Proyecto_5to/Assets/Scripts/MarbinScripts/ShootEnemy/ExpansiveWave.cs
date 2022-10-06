using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExpansiveWave : MonoBehaviour
{
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
        if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }

        /*if (Input.GetKeyDown(KeyCode.Y))
        {
            Explotion();
            Debug.Log("Explosion");
        }*/
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
}
