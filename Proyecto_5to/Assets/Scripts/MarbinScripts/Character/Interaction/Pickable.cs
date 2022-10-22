using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    public GameObject cube;
    public Transform hand;
    public Rigidbody rbd;
    public BoxCollider box;
    public bool active, release, inHand;
    public float force;
    private Vector3 escale;
    public Energy energy;
    public float maxTimer;
    public float time;
    public override void Interact()
    {
        base.Interact();
        Grab();
    }
    public void Grab()
    {
            if (release && energy.energy > 4)
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
        time = time + Time.deltaTime;
        if (time >= 0.1)
        {
            time -= 1;
            if (energy.energy >= 0 && inHand)
            {
                energy.energy -= 10;
            }
        }
    }
}
