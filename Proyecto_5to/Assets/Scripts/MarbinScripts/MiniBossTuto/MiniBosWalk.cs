using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MiniBosWalk : MonoBehaviour
{
    [Header("Movimiento")]
    public Transform[] points;
    public NavMeshAgent agent;
    public int destPoint = 0;


    public float detecte;
    public Transform player;
    public bool view;
    public Rigidbody rb;
    public MoveRGB move;

    public bool charge;
    public bool tackle;
    public Life lifeProta;
    void Start()
    {
        
    }

    void Update()
    {       
        if (agent.remainingDistance < 0.5f && !view)
        {
            GotoNextPoint();
        }
        Detectec();
    }

    public void Detectec()
    {
        //Taclear
        if (charge == true)
        {
            if (Vector3.Distance(transform.position, player.position) < detecte)
            {
                tackle = true;
                //Debug.Log("Player");
                view = true;
                agent.destination = player.position;
                agent.speed = 10;
            }
            else
            {
                tackle=false;
                view = false;
            }
        }
        
    }

    public void GotoNextPoint()
    {
        agent.speed = 3.5f;
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
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(Vector3.left * 18, ForceMode.Impulse);
            rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
            agent.speed = 0;
            move.move = false;
            StartCoroutine(FalseMove());
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (tackle)
            {
                rb.AddForce(Vector3.left * 18, ForceMode.Impulse);
                rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
                agent.speed = 0;
                move.move = false;
                StartCoroutine(FalseMove());
                lifeProta.life -= 100;
            }
            
        }
    }

    public IEnumerator FalseMove()
    {
        yield return new WaitForSeconds(1);
        move.move = true;
        yield return new WaitForSeconds(2);
        agent.speed = 3.5f;
    }
}
