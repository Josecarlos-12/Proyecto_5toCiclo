using System.Collections;
using System.Collections.Generic;
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
        if (other.gameObject.CompareTag("Bullet"))
        {
            render.material.color = Color.red;
            life -= bullet.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("LaserProta"))
        {
            render.material.color = Color.red;
            life -= laser.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            render.material.color = Color.red;
            life -= sword.damage;
            Debug.Log("Macheteo");
            StartCoroutine(ChangeColor());
        }
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
