using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Larry : MonoBehaviour
{
    [Header("Movimiento")]
    public Transform[] points;
    public float distancePoint;
    public NavMeshAgent agent;
    public int destPoint = 0;
    public float speedMin, speedMax;

    [Header("Seguimiento")]
    public GameObject player;
    public float detecte, detectePunch;    
    public bool view;
    public Rigidbody rb;

    [Header("Ataque")]
    public Animator anim;
    public bool punch;

    [Header("Life")]
    public float life;
    public Sword sword;
    public Bullet bullet, laser; 
    public Renderer render;
    public GameObject larryContainer;

    [Header("Empuje")]
    public int count;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (agent.remainingDistance < distancePoint && !view && !punch)
        {
            GotoNextPoint();
        }
        Detectec();
        DetectecPunch();
        Life();
    }

    public void Life()
    {
        if (life <= 0)
        {
            Destroy(larryContainer);
        }
    }

    public void Detectec()
    {
        //Taclear       
         if (Vector3.Distance(transform.position, player.transform.position) < detecte )
         {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            Debug.Log("Player");
            view = true;
            agent.destination = player.transform.position;
            agent.speed = 20;
            //agent.stoppingDistance = 3f;
        }
        else
        {
            agent.speed = 4;
            //agent.stoppingDistance = 1;
            view = false;
         }
    }

    public void DetectecPunch()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < detectePunch)
        {
            anim.SetBool("Attack", true);
            agent.destination = transform.position;
            agent.speed = 0;
            Debug.Log("Punch");
            punch = true;
        }
        else
        {
            anim.SetBool("Attack", false);
            punch = false;
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
                StartCoroutine(Empuje());
                StartCoroutine(ChangeColor());
                life -= 60;
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detecte);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectePunch);
    }
}
