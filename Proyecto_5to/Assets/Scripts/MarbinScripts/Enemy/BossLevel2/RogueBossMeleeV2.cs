using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBossMeleeV2 : MonoBehaviour
{
    public bool Active;
    public GameObject Weapon;
    public Animator Anim;

    void Start()
    {
        Anim = Weapon.GetComponent<Animator>();
    }

    void Update()
    {
        if (Active)
        {
            Anim.SetBool("Melee", true);
            Active = false;
        }
        else
        {
            Anim.SetBool("Melee", false);
        }
    }
}
