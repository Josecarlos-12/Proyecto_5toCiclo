using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator anim;
    public bool attack;
    public GameObject sword;
    public GameObject colliderSword;
    public bool on;
    public float time = 0.2f;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            on = !on;
            if (on)
            {
                attack = true;
                sword.SetActive(true);
                //sword.SetActive(true);
                //anim.SetBool("Save", false);
                //StopCoroutine("DesactiveSword");
               


            }
            else
            {
                sword.SetActive(false);
                attack = false;
                //anim.SetBool("Save", true);
                //StartCoroutine("DesactiveSword");
            }
            
        }

        if (Input.GetMouseButtonDown(1) && attack)
        {
            anim.SetBool("Attack", true);
            StartCoroutine("DesactiveSword");
            
            //colliderSword.tag = "Sword";
        }
        else if (Input.GetKeyUp(KeyCode.F) && !attack)
        {
           // anim.SetBool("Attack", false);
        }
    }

    public IEnumerator DesactiveSword()
    {
        yield return new WaitForSeconds(time);
        //sword.SetActive(false);
        anim.SetBool("Attack", false);
        
       // colliderSword.tag = "Untagged";
    }
}
