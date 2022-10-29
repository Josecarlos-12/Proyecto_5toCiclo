using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTuto : MonoBehaviour
{
    public RespawnGigant respawn;
    public MoveRGB move;
    public Jump jump;
    public bool touch;
    public DashController dash;
    public Weapon weaponA, weaponB;
    public CameraView cameraView;
    public Shield shieldActive;

    public enum Interactions
    {
        move,
        jump,
        crouch,
        doubleJump,
        dash,
        shoot,
        shield
    }
    public Interactions interactions;
    private void Update()
    {
        if(touch && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("TocoE");
            respawn.prota.position = new Vector3(respawn.next[0].position.x, respawn.next[0].position.y + 3, respawn.next[0].position.z);
            respawn.prota.rotation = Quaternion.Euler(0, 0, 0);
            //respawn.cameraPosition.rotation = Quaternion.Euler(0, 0, 0);
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
            case Interactions.doubleJump:
                if (other.gameObject.CompareTag("Player"))
                {
                    jump.jumpTwo=true;
                    jump.jumpOne = false;
                }
                break;
            case Interactions.dash:
                if (other.gameObject.CompareTag("Player"))
                {
                    dash.canDash = true;
                }
                break;
            case Interactions.shoot:
                if (other.gameObject.CompareTag("Player"))
                {
                    weaponA.canShoot = true;
                    weaponB.canShoot = true;
                    cameraView.aim = true;
                }
                break;
            case Interactions.shield:
                if (other.gameObject.CompareTag("Player"))
                {
                    shieldActive.canShild = true;
                }
                break;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        touch = false;
    }
}
