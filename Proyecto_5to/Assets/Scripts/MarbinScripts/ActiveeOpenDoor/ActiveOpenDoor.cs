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

            if (open)
            {
                if(count<3)
                count++;

                if(count==1)
                BoosCamera();
                if (count == 2  || count == 3)
                {
                    res.prota.position = new Vector3(res.next[5].position.x, res.next[5].position.y + 3, res.next[5].position.z);
                    res.prota.rotation = res.next[5].rotation;
                }
            }
        }
    }
    public void BoosCamera()
    {
        prota.SetActive(false);
        cam.SetActive(true);
        doorDown.SetBool("Open", true);
        StartCoroutine(Camerafalse());
    }

    public IEnumerator Camerafalse()
    {
        yield return new WaitForSeconds(3);
        prota.SetActive(true);
        cam.SetActive(false);
    }
}
