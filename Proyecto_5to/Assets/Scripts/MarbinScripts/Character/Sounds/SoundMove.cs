using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMove : MonoBehaviour
{
    public bool floor;
    public MoveRGB move;
    [Header("Pasos Sonidos")]
    public AudioSource footSteps;
    public NewJump jump;


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
                if (!footSteps.isPlaying && move.move)
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

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Platform"))
        {
            floor = true;
            jump.currentJumps = 0;
            jump.canJump = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Platform"))
        {
            floor = false;
            jump.canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
           
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            
        }
    }
}
