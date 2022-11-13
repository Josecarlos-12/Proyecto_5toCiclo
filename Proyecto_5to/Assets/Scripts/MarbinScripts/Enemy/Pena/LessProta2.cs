using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessProta2 : MonoBehaviour
{
    public PenaV2 pena;
    public Collider col;
    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pena.agent.speed = 0;
            //pena.move.move = false;
            StartCoroutine("LarryFalse");
            //pena.rb.AddForce(((Vector3)(other.gameObject.transform.position - transform.position)).normalized * 30, ForceMode.Impulse);
            pena.rb.AddForce(new Vector3(other.gameObject.transform.position.x - transform.position.x, 0, other.gameObject.transform.position.z - transform.position.z).normalized * 10, ForceMode.Impulse);
            pena.lifeProta.life -= 50;
            //col.enabled = false; 
            Debug.Log("Bajo 50");
        }
    }

    public IEnumerator LarryFalse()
    {
        yield return new WaitForSeconds(0.2f);
        col.enabled = true;
    }
}
