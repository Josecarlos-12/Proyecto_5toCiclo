using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJump : MonoBehaviour
{
    public int maxJumps;
    public int currentJumps;
    public bool canJump;

    public AudioSource audioJump;
    public Energy energy;

    public bool doubleJump;

    public Rigidbody rb;
    public float jumpHeight = 8;
    public float gravity=4;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentJumps = 0;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("DoubleJump") == 1)
        {
          doubleJump = true;
        }
        CheckForJumpInput();

        if (!canJump)
        {
            StartCoroutine(Gravity());
        }
    }

    public IEnumerator Gravity()
    {
        yield return new WaitForSeconds(0.4f);
        rb.AddForce(Vector3.down * gravity, ForceMode.Impulse);
    }

    void CheckForJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentJumps < maxJumps)
            {
                audioJump.Play(); 
                
                if (!doubleJump)
                    Jump();

                if (doubleJump)
                    JumpNormal();
            }
        }
    }

    void Jump()
    {
        maxJumps = 1;

        currentJumps = currentJumps + 1;

        Vector2 vel = GetComponent<Rigidbody>().velocity;
        vel.y = 5;
        //GetComponent<Rigidbody>().velocity = vel;
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    public void JumpNormal()
    {
        currentJumps = currentJumps + 1;

        Vector2 vel = GetComponent<Rigidbody>().velocity;
        vel.y = 5;
        //GetComponent<Rigidbody>().velocity = new Vector3(0, vel.y,0);
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

        if (currentJumps == 2)
        {
            energy.ReductionEnergyJump();             
        }
        if (energy.energy > 150)
        {
            maxJumps = 2;
        }
        else if (energy.energy < 150)
        {
            maxJumps = 1;
        }
    }



}
