using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GrabObjects : MonoBehaviour
{
    public GameObject cube;
    public Transform hand, handTwo;
    public Rigidbody rbd;
    public BoxCollider box;
    public bool active, release, inHand;
    public float force;
    private Vector3 escale;
    public Energy energy;
    public float maxTimer;
    public float time;

    void Start()
    {
        rbd.GetComponent<Rigidbody>();
        escale = cube.transform.localScale;
    }

    void Update()
    {
        Grab();
        LessEnergy();
    }

    public void Grab()
    {
        if (active && Input.GetKeyUp(KeyCode.R))
        {
            release = !release;
            if (release && energy.energy>4)
            {
                cube.transform.SetParent(hand);
                cube.transform.position = hand.position;
                cube.transform.rotation = hand.rotation;
                box.isTrigger = true;
                rbd.isKinematic = true;
                inHand = true;
            }
            else
            {
                LeaveObject();
                inHand = false;
            }           
        }
        if (energy.energy < 4)
        {
            LeaveObject();
            inHand = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            LeaveObject();
            if (inHand)
            {
                rbd.AddForce(transform.forward * force, ForceMode.Impulse);
                inHand = false;
            }
        }
    }

    public void LeaveObject()
    {
        cube.transform.SetParent(null);
        box.isTrigger = false;
        rbd.isKinematic = false;
        cube.transform.localScale = escale;        
    }

    public void LessEnergy()
    {
        time =time+Time.deltaTime;
        if (time >= 0.1)
        {
            time -= 1;
            if (energy.energy >= 0 && inHand)
            {
                energy.energy -= 10;
            }            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            active = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            active = false;
        }
    }

}
