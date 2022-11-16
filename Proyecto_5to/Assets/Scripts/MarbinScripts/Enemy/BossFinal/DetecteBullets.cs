using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecteBullets : MonoBehaviour
{
    public BossFinalMArbin boss;
    public Transform point;
    public bool detecte;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (detecte)
        {
            boss.agent.destination = point.transform.position;
            boss.agent.speed = 15;
            StartCoroutine(FalseBullet());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Bala");
            
            detecte = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            
        }
    }

    public IEnumerator FalseBullet()
    {
        yield return new WaitForSeconds(4);
        boss.agent.speed = 0;
        detecte = false;
    }
}
