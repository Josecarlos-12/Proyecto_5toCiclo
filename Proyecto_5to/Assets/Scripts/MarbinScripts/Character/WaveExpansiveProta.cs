using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveExpansiveProta : MonoBehaviour
{
    [Header("Onda Expansiva")]
    public float radius;
    public float forceExplotion;

    public Rigidbody rb;
    public float jump;

    public bool canExplotion;

    private void Update()
    {
        Explotion();
    }

    public void Explotion()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (canExplotion)
            {
                canExplotion = false;
                StartCoroutine(ExplotioTrue());
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);

                Collider[] objects = Physics.OverlapSphere(transform.position, radius);

                foreach (Collider obj in objects)
                {
                    Rigidbody rb2d = obj.GetComponent<Rigidbody>();
                    if (rb2d != null)
                    {
                        Vector3 direction = obj.transform.position - transform.position;
                        float distance = 0.3f + direction.magnitude;
                        float forceInitial = forceExplotion / distance;
                        rb2d.AddForce(direction * forceInitial);
                    }
                }
            }           
        }
       
    }

    public IEnumerator ExplotioTrue()
    {
        yield return new WaitForSeconds(3);
        canExplotion = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
