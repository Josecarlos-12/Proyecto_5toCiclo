using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrittlePlatform : MonoBehaviour
{
    public float waitingTime;
    public float respawntime;
    public Rigidbody rb;
    public Collider collision;
    Vector3 start;

    public Animator anim;

    [Header("Sonido")]
    public AudioSource audi;
    public int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collision = GetComponent<Collider>();
        start = transform.position;
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (count < 3)
                count++;

            if (count == 1)
            {
                audi.Play();
            }

            Debug.Log("contacto");
            StartCoroutine(Waiting());
            anim.SetBool("Shake", true);
        }
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitingTime);
        rb.isKinematic = false;
        collision.isTrigger = true;
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawntime);
        count = 0;
        transform.position = start;
        //rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        collision.isTrigger = false;
        anim.SetBool("Shake", false);
    }
}
