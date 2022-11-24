using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoBullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speedBullet;
    public float destructtion;
    public float damageB;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, destructtion);
        rb.AddForce(transform.forward * speedBullet);
    }


    public enum Destruction
    {
        One,
        Two
    } 
    public Destruction destruction;
    private void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (destruction)
        {
            case Destruction.One:
                if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Shield") || other.gameObject.CompareTag("Big"))
                {
                    //GameObject bulletClone = Instantiate(bulletHolePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(new Vector3(transform.rotation.x, 0,0)));
                    Destroy(gameObject);
                    //Destroy(bulletClone, 2f);
                }
                break;
            case Destruction.Two:
                if (other.gameObject.CompareTag("Enemy") ||  other.gameObject.CompareTag("Shield"))
                {
                    //GameObject bulletClone = Instantiate(bulletHolePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(new Vector3(transform.rotation.x, 0,0)));
                    Destroy(gameObject);
                    //Destroy(bulletClone, 2f);
                }
                break;
        }
       

    }
}
