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


    public float detecte, detecteTacle;
    public Transform player;
    public bool view;
    public Rigidbody rb;
    public MoveRGB move;

    public bool charge;
    public bool tackle;
    public Life lifeProta;
    public bool canMove = true;

    [Header("Velocidades")]
    public float speedNormal;
    public float speedSuper = 40, aceleration = 25 , acelerationNormal=8;
    public bool bAnimTacle, tacleOn;
    public float force = 30;

    public Animator anim;

    public bool funtionAll;


  


    void Start()
    {
    }

    void Update()
    {       
        if (canMove)
        {
            if (agent.remainingDistance < 0.5f && !view)
            {
                GotoNextPoint();
            }
        }
        Detectec();               
    }

    public void Detectec()
    {
        //Taclear
        if (charge == true)
        {
            if (Vector3.Distance(transform.position, player.position) < detecte && !tacleOn)
            {
                tackle = true;
                //Debug.Log("Player");
                view = true;
                agent.destination = player.position;
                agent.speed = speedNormal;
                agent.acceleration = acelerationNormal;
            }
            else
            {
                tackle=false;
                view = false;
            }

            if (Vector3.Distance(transform.position, player.position) < detecteTacle && !tacleOn)
            {
                agent.speed = 0;
                anim.SetBool("Tacle", true);
                StartCoroutine(AnimTacle());
            }
        }

        if (tacleOn)
        {
            agent.speed = 0;
        }
        
    }

    public IEnumerator AnimTacle()
    {
        yield return new WaitForSeconds(0.1f);
        agent.speed = speedSuper;
        agent.acceleration = aceleration;
       
        yield return new WaitForSeconds(0.9f);
        anim.SetBool("Tacle", false);
        
    }

   

    public void GotoNextPoint()
    {
        agent.acceleration = 8;
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

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detecteTacle);
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
                tacleOn = true;
                //rb.AddForce(Vector3.left * 18, ForceMode.Impulse);
                rb.AddForce(new Vector3(other.gameObject.transform.position.x - transform.position.x, 0, other.gameObject.transform.position.z - transform.position.z).normalized * force, ForceMode.Impulse);
                //rb.AddForce(Vector3.up * 1, ForceMode.Impulse);
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
        yield return new WaitForSeconds(2f);
        tacleOn = false;
    }
}
