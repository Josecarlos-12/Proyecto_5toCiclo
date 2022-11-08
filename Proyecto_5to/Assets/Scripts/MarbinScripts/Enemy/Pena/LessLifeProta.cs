using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessLifeProta : MonoBehaviour
{
    public Pena pena;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pena.agent.speed = 0;
            pena.move.move = false;
            StartCoroutine("LarryFalse");
            if (pena.count == 0)
            {
                pena.lifeProta.life -= 200;
                pena.rb.AddForce(((Vector2)(other.gameObject.transform.position - transform.position)).normalized * 20, ForceMode.Impulse);
            }
            
            pena.attack = true;
            Debug.Log(pena.lifeProta.life);

            pena.count = 1;

            if(pena.count == 1)
            {
                pena.lifeProta.life -= 50;
                pena.rb.AddForce(((Vector2)(other.gameObject.transform.position - transform.position)).normalized * 8, ForceMode.Impulse);
            }
            /*if (pena.count == 1 && !pena.attack)
            {
                pena.lifeProta.life -= 200;                
                pena.rb.AddForce(((Vector2)(other.gameObject.transform.position - transform.position)).normalized * 20, ForceMode.Impulse);
                pena.attack = true;
                Debug.Log(pena.lifeProta.life);
            }
            if (pena.count == 1 && pena.attack)
            {
                pena.lifeProta.life -= 50;
                pena.rb.AddForce(((Vector2)(other.gameObject.transform.position - transform.position)).normalized * 6, ForceMode.Impulse);
                Debug.Log(pena.lifeProta.life);
            }*/
        }
    }

    public IEnumerator LarryFalse()
    {
        yield return new WaitForSeconds(0.3f);
        pena.move.move = true;
    }
}
