using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{        
    public float time;
    public AudioSource audioNormal, audioBoss;
    public float volumeNormmal, volumeBoss;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fade")
        {
            //audioNormal.volume= audioNormal.volume-
        }
    }
}
