using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessProta2 : MonoBehaviour
{
    public Pena pena;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pena.agent.speed = 0;
            pena.move.move = false;
            StartCoroutine("LarryFalse");
            pena.rb.AddForce(((Vector2)(other.gameObject.transform.position - transform.position)).normalized * 5, ForceMode.Impulse);
            pena.lifeProta.life -= 50;            
        }
    }

    public IEnumerator LarryFalse()
    {
        yield return new WaitForSeconds(0.3f);
        pena.move.move = true;
    }
}
