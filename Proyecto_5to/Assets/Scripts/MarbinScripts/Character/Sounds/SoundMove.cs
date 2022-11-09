using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMove : MonoBehaviour
{
    public bool floor; 
    [Header("Pasos Sonidos")]
    public AudioSource footSteps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (floor)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (!footSteps.isPlaying)
                {
                    footSteps.Play();
                }
            }
            else
            {
                footSteps.Pause();
                //footSteps.Stop();
            }
        }
        else
        {
            footSteps.Pause();
            //footSteps.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Platform"))
        {
            floor = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Platform"))
        {
            floor = false;
        }
    }
}
