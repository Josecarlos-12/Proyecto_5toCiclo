using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{        
    public float time, maxTime;
    public AudioSource audioNormal, audioBoss;
    public float volumeNormmal=0.3f, volumeBoss=0.3f;
    public bool touch;
    public Collider col;


    void Update()
    {
        if (touch)
        {

            time += Time.deltaTime;

            if (time <= maxTime)
            {
                time = 0; 
                audioNormal.volume -= volumeNormmal;
                audioBoss.volume += volumeBoss;
            }
            

            if(audioNormal.volume <= 0.3f)
            {
                audioNormal.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioBoss.enabled = true;
            touch = true;
            col.enabled = false;
        }
    }
}
