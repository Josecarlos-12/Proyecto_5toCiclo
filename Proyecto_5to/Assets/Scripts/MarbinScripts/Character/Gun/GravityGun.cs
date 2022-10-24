using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Transform cam;
    public Transform objectHold;
    public Transform objectAim;

    public float distance = 9.0f;
    public bool holdingObject;

    public bool holdEnable = true;

    public LayerMask layer;
    void Update()
    {
        bool isAimingObject = IsAimingObject();

        if (isAimingObject)
        {
            if (Input.GetMouseButton(1))
            {
                if(!holdingObject && holdEnable)
                {
                    float d = Vector3.Distance(objectAim.position, transform.position);
                    if(d > 2.0f)
                    {
                        float force = 3.0f;
                        Vector3 dirToPlayer = cam.position - objectAim.position;
                        Rigidbody rb=objectAim.GetComponent<Rigidbody>();
                        rb.AddForce(dirToPlayer * force, ForceMode.Force);
                    }
                    else
                    {
                        LockOject();
                    }
                }
            }
        }

        if (holdingObject)
        {
            if (Input.GetMouseButtonDown(1))
            {
                RealeaseObject(Vector3.zero);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                RealeaseObject((transform.forward + Vector3.up * 0.2f).normalized * 20.0f);
            }
        }
    }

    public void RealeaseObject(Vector3 newVelocity)
    {
        holdingObject = false;
        objectHold.parent = null;

        Rigidbody objectRigidbody=objectHold.GetComponent<Rigidbody>();
        objectRigidbody.useGravity = true;
        objectRigidbody.constraints = RigidbodyConstraints.None;
        objectRigidbody.velocity = newVelocity;

        objectHold = null;
        holdEnable = false;

        Invoke("EnableHold", 1.0f);
    }

    public bool IsAimingObject()
    {
        RaycastHit hit;
        bool isAimingObject = Physics.Raycast(cam.position, transform.TransformDirection(Vector3.forward), out hit, distance, layer);
        if (isAimingObject)
        {
            objectAim = hit.transform;
        }
        return isAimingObject;
    }

    public void LockOject()
    {
        holdingObject = true;
        objectHold = objectAim;
        objectAim = null;

        objectHold.position = transform.position + transform.forward *4f;
        objectHold.rotation = transform.rotation;

        Rigidbody objectRigidbody=objectHold.GetComponent<Rigidbody>();
        objectRigidbody.useGravity = false;
        objectRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        objectRigidbody.velocity = Vector3.zero;

        objectHold.transform.parent = transform;
    }

    public void EnableHold()
    {
        holdEnable = true;
    }
}
