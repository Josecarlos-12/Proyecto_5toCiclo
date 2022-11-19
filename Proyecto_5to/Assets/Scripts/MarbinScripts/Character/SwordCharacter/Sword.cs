using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    public Animator anim;
    public bool attack;
    public GameObject sword;
    public GameObject colliderSword;
    public bool on;
    public float time = 0.2f;
    public float damage=50;
    public bool animRep;
    public bool canAtack;

    public Color swordInitial;
    public Image swordImage;

    [Header("Espada Efecto")]
    public AudioSource swordAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canAtack)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                on = !on;
                if (on)
                {
                    swordImage.color = Color.white;
                    attack = true;
                    sword.SetActive(true);
                    //sword.SetActive(true);
                    //anim.SetBool("Save", false);
                    //StopCoroutine("DesactiveSword");



                }
                else
                {
                    swordImage.color = swordInitial;
                    sword.SetActive(false);
                    attack = false;
                    //anim.SetBool("Save", true);
                    //StartCoroutine("DesactiveSword");
                }

            }

            if (Input.GetMouseButtonDown(1) && attack && !animRep)
            {
                swordAudio.Play();
                anim.SetBool("Attack", true);
                StartCoroutine("DesactiveSword");
                animRep = true;
                //colliderSword.tag = "Sword";
            }
            else if (Input.GetKeyUp(KeyCode.F) && !attack)
            {
                // anim.SetBool("Attack", false);
            }
        }        
    }

    public IEnumerator DesactiveSword()
    {
        yield return new WaitForSeconds(time);
        //sword.SetActive(false);
        anim.SetBool("Attack", false);
        animRep=false;
       // colliderSword.tag = "Untagged";
    }
}
