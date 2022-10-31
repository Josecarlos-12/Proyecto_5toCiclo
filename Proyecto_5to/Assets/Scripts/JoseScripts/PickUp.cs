using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.XR;

public class PickUp : MonoBehaviour
{
    public float pickUpRange = 5;
    public float moveForce = 250;
    public Transform holdParent;

    public GameObject heldObj;
    public LayerMask layer;

    [Header("Bajar Energia")]
    public float maxTimer=0.1f;
    public float time;
    public Energy energy;
    public bool lessEner;

    [Header("Disparar")]
    public float force;
    public bool inHand;
    public enum Guns
    {
        gunOne,
        gunTwo
    }
    public Guns guns;

    void Update( )
    {
        switch (guns)
        {
            case Guns.gunOne:
                GunOne();
                break;
            case Guns.gunTwo:
                GunTwo();
                break;
        }
    }

    public void GunOne()
    {
        LessEnergy();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange, layer))
                {
                    PickupObject(hit.transform.gameObject); Debug.Log("CogioObjeto");
                }
            }
            else
            {
                DropObject(); Debug.Log("SoltoObjeto");
            }
            /*if (Input.GetMouseButtonDown(0))
            {
                DropObject();
                Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
                heldRig.AddForce(transform.forward * force, ForceMode.Impulse);
            }*/
        }
        if (energy.energy < 4)
        {
            if (heldObj != null)
            {
                DropObject();
            }

        }
        if (heldObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject( )
    {
        if ( Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f )
        {
            Vector3 moveDirection = ( holdParent.position - heldObj.transform.position ); 
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if ( pickObj.GetComponent<Rigidbody>() )
        {
            lessEner = true;
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            //objRig.isKinematic = true;
            objRig.drag = 10;
            objRig.constraints = RigidbodyConstraints.FreezePositionX;
            objRig.constraints = RigidbodyConstraints.FreezePositionZ;
            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
       

        lessEner = false; 

        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        //heldRig.isKinematic = false;
        heldRig.drag = 1;
        heldRig.constraints = ~RigidbodyConstraints.FreezeAll;

        heldObj.transform.parent = null;
        heldObj = null; 
    }

    public void LessEnergy()
    {
        if (lessEner)
        {
            time = time + Time.deltaTime;
            if (time >= maxTimer)
            {
                time -= 1;
                if (energy.energy >= 0)
                {
                    energy.energy -= 10;
                }
            }
        }
       
    }

    //Arma Dos
    public void GunTwo()
    {
        LessEnergy();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange, layer))
                {
                    PickupObjectTwo(hit.transform.gameObject); Debug.Log("CogioObjeto");
                }
            }
            else
            {
                DropObjectTwo(); Debug.Log("SoltoObjeto");
            }
        }
        if (energy.energy < 4)
        {
            if (heldObj != null)
            {
                DropObjectTwo();
            }

        }
        if (heldObj != null)
        {
            //MoveObjectTwo();
        }
    }


    void PickupObjectTwo(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            lessEner = true;
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.transform.SetParent(holdParent.transform);
            objRig.useGravity = false;
            objRig.isKinematic = true;
            heldObj = pickObj;
        }
    }

    void DropObjectTwo()
    {

        lessEner = false;

        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.isKinematic = false;
        heldObj.transform.parent = null;
        heldObj = null;
    }
}
