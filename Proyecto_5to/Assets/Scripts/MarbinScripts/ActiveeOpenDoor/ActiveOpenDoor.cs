using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOpenDoor : MonoBehaviour
{
    public GameObject Door;
    public Animator anim, anim2, anim3;
    public GameObject prota, cam;
    public Animator doorDown;

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

            switch (bos)
            {
                case Boss.one:
                    break;
                case Boss.two:
                    BoosCamera();
                    break;
            }
        }
    }
}
