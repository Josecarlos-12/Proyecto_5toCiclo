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
            pena.move.move = false;
            StartCoroutine("LarryFalse");
            pena.rb.AddForce(((Vector2)(other.gameObject.transform.position - transform.position)).normalized * 30, ForceMode.Impulse);
            pena.lifeProta.life -= 50;
            col.enabled = false; Debug.Log("Bajo 50");
        }
    }

    public IEnumerator LarryFalse()
    {
        yield return new WaitForSeconds(0.3f);
        pena.move.move = true;
        yield return new WaitForSeconds(0.2f);
        col.enabled = true;
    }
}
