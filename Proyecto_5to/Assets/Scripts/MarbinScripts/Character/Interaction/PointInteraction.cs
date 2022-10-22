using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointInteraction : MonoBehaviour
{
    [Header("Raycast")]
    public Transform point;
    public float rayDistance;

    [Header("Agarrar Objeto")]
    public GameObject cube;
    public Transform hand, handTwo;
    public Rigidbody rbd;
    public BoxCollider box;
    public bool  release, inHand;
    public float force;
    private Vector3 escale;
    public Energy energy;
    public float maxTimer;
    public float time;


    private void Update()
    {

        RaycastHit hit;
        

        if (Physics.Raycast(point.position,point.forward, out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Big"))
            {
                Debug.Log("Toco Box");
            }
            else
            {
                Debug.Log("No toco Box");
            }

        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(point.position, point.forward * rayDistance, Color.blue);
    }


}
