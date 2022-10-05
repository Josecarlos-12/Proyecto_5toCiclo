using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletHolePrefab;
    public Rigidbody rb;
    public float speedBullet;
    public float destructtion;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, destructtion);
        rb.AddForce(transform.forward * speedBullet);
    }

    private void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Shield"))
        {
            //GameObject bulletClone = Instantiate(bulletHolePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(new Vector3(transform.rotation.x, 0,0)));
            Destroy(gameObject);
            //Destroy(bulletClone, 2f);
        }

    }

}
