using MarwanZaky.MathfX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotinIAMove : MonoBehaviour
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

    public float life=3;
    public GameObject robotin;

    public Renderer render;

    public GameObject experience;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        Life();
        if (robotin != null)
        {
            Destination();
        }
        
    }

    public void Life()
    {
        if (life <= 0)
        {
            Instantiate(experience, transform.position, Quaternion.identity);
            Instantiate(experience, new Vector3 (transform.position.x+2,transform.position.y,transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void Destination()
    {

        if (Physics.CheckSphere(transform.position, AlertRange, playerMask))
        {
            if (life > 0)
            {
                agent.destination = target.transform.position;
                agent.stoppingDistance = 4;
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
            render.material.color = Color.red;
            life-=20;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            render.material.color = Color.red;
            life -=50;
            Debug.Log("Macheteo");
            StartCoroutine(ChangeColor());
        }
    }


    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        render.material.color = Color.white;
    }
}
