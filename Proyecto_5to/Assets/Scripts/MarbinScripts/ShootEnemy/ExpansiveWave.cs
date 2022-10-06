using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansiveWave : MonoBehaviour
{
    public float radius;
    public float forceExplotion;

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Explotion();
            Debug.Log("Explosion");
        }
    }

    public void Explotion()
    {
        Collider[] objects=Physics.OverlapSphere(transform.position, radius);

        foreach (Collider obj in objects)
        {
            Rigidbody rb2d=obj.GetComponent<Rigidbody>();
            if (rb2d != null)
            {
                Vector3 direction=obj.transform.position-transform.position;
                float distance = 0.3f + direction.magnitude;
                float forceInitial = forceExplotion / distance;
                rb2d.AddForce(direction * forceInitial);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
