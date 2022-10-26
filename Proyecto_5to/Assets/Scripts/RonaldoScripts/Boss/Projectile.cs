using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject TimeZone;
    public GameObject Zone;

    public GameObject sphre;

    public float speed = 2;
    public float timer;
    float ti;
    bool damage;

    void Start()
    {
        TimeZone.transform.localScale = Vector3.zero;
    }
    void Update()
    {
        timer += Time.deltaTime;
        TimeZone.transform.localScale = Vector3.Lerp(TimeZone.transform.localScale, Zone.transform.localScale,speed*Time.deltaTime);

        
        ti += Time.deltaTime * 0.5f;
        sphre.transform.position = Vector3.Lerp(sphre.transform.position,Zone.transform.position, ti);

        if (timer > 2.5)
        {
            Debug.Log("explosion");
            Destroy(this.gameObject);
        }
        if (timer > 2.4)
        {
            damage = true;  
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && damage)
        {
            Debug.Log("Daño recibido");
        }
    }
}
