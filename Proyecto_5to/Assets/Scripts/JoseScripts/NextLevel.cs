using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public Transform prota;
    public Transform[] mod;
    public Life life;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Mod2")
        {
            prota.position=mod[0].position;
            //life.positionInitial.position = mod[0].position;
        }
        if (other.gameObject.name == "Mod3")
        {
            prota.position = mod[1].position;
            //life.positionInitial.position = mod[1].position;
        }
    }
}
