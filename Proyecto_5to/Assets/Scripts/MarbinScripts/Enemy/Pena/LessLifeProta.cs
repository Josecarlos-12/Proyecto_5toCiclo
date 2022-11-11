using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessLifeProta : MonoBehaviour
{
    public PenaV2 pena;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pena.move.move = false;
            StartCoroutine("LarryFalse"); Debug.Log("Bajo 200");
            // circle.SetActive(false);
            //circleTwo.SetActive(true);
            //pena.rb.AddForce(((Vector2)(other.gameObject.transform.position - transform.position)).normalized * 10, ForceMode.Impulse);
            pena.rb.AddForce(((Vector3)(other.gameObject.transform.position - transform.position)).normalized * 35, ForceMode.Impulse);
            pena.lifeProta.life -= 200;
            pena.col.SetActive(false);
            pena.col2.SetActive(true);
            pena.bColl = true;
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
