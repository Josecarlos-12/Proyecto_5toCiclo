using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InteractionTuto : MonoBehaviour
{
    public RespawnGigant respawn;
    public MoveRGB move;
    public Jump jump;
    public bool touch;

    public enum Interactions
    {
        move,
        jump,
        crouch
    }
    public Interactions interactions;
    private void Update()
    {
        if(touch && Input.GetKeyDown(KeyCode.E))
        {
            respawn.prota.position = new Vector3(respawn.next[0].position.x, respawn.next[0].position.y + 3, respawn.next[0].position.z);
            move.move = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (interactions)
        {
            case Interactions.move:
                if (other.gameObject.CompareTag("Player"))
                {
                    touch = true;
                }
                break;

            case Interactions.jump:
                if (other.gameObject.CompareTag("Player"))
                {
                    jump.jumpOne = true;
                }                
                break;
            case Interactions.crouch:
                if (other.gameObject.CompareTag("Player"))
                {
                    move.canCrouch = true;
                }
                break;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        touch = false;
    }
}
