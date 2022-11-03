using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeEnemy : MonoBehaviour
{
    public float Timer = 5;
    public float speed = 2;
    Transform PlayerPosition;
    Animator animator;
    CapsuleCollider coll;
    float timer;
    public bool Active = false ;
    bool Move = false;

    void Start()
    {

        animator = GetComponent<Animator>();
        PlayerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>();
        coll = GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        transform.LookAt(new Vector3(PlayerPosition.position.x, transform.position.y, PlayerPosition.position.z));
        if (Active)
        {
            if (Move)
            {
                Mover();
            }
            timer += Time.deltaTime;
            if(timer > Timer)
            {
                animator.SetBool("End",true) ;
                Move = false;
                coll.isTrigger = false;
                if (timer > Timer + 1.5f)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                Move = true;
            }
        }
    }
    public void Activar()
    {
        Active = true;
        coll.isTrigger = false;
    }
    void Mover()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerPosition.position.x, transform.position.y, PlayerPosition.position.z), speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Move = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Move = true;
        }
    }
}
