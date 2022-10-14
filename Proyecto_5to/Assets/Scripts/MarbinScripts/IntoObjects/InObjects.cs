using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InObjects : MonoBehaviour
{
    public float radius;
    public int count;
    

    public void Explotion()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider obj in objects)
        {
            if (obj.gameObject.CompareTag("Big"))
            {
                Debug.Log(obj.name);
                count++;
            }
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
