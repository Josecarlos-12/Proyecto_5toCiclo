using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOpenDoor : MonoBehaviour
{
    public GameObject Door;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Door.SetActive(true);

            if (anim != null)
            {
                anim.SetBool("Open", true);
            }
        }
    }
}
