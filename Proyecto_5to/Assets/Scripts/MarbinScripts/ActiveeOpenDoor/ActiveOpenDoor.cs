using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ActiveOpenDoor : MonoBehaviour
{
    public GameObject Door;
    public Animator anim, anim2, anim3;
    public GameObject prota, cam;
    public Animator doorDown;
    public bool open;
    public int count;
    public RespawnGigant res;

    public enum Boss
    {
        one, two
    }
    public Boss bos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (anim != null)
            {
                anim.SetBool("Open", true);
            }
            if (anim2 != null)
            {
                anim2.SetBool("Open", true);
            }
            if (anim3 != null)
            {
                anim3.SetBool("Open", true);
            }
        }
    }

    public void BoosDoor()
    {
      
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Door.SetActive(true);

            if (anim != null)
            {
                anim.SetBool("Open", true);
            }
            if (anim2 != null)
            {
                anim2.SetBool("Open", true);
            }
            if (anim3 != null)
            {
                anim3.SetBool("Open", true);
            }


        }
    }
   
}
