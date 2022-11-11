using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveHabilities : MonoBehaviour
{
    public Jump jump;
    public DashController dash;
    public Weapon weapon;
    public Sword sword;

    public GameObject question;
    public RespawnGigant respawn;
    public Image shoot;
    private void Start()
    {
        //PlayerPrefs.SetInt("DoubleJump", 0);
        //PlayerPrefs.SetInt("Dash", 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Jump")
        {
            jump.jumpOne = false;
            jump.jumpTwo = true;
            dash.canDash = true;
        }
        if(other.gameObject.name == "Question")
        {
            Destroy(other.gameObject);
            question.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

        if (other.gameObject.name == "Aim")
        {
            shoot.color = Color.white;
            weapon.canShoot = true;
        }

        if (other.gameObject.name == "SwordAttack")
        {
            sword.canAtack = true;
        }
    }
    
    public void YesDoJumo()
    {
        PlayerPrefs.SetInt("DoubleJump", 1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        question.SetActive(false);
        dash.canDash = false;
        respawn.prota.position = new Vector3(respawn.next[2].position.x, respawn.next[2].position.y + 3, respawn.next[2].position.z);
        respawn.prota.rotation = respawn.next[2].rotation;
    }

    public void Dash()
    {
        PlayerPrefs.SetInt("Dash", 1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        question.SetActive(false);
        jump.jumpTwo = false;
        jump.jumpOne = true;
        jump.maxJumpCount = 1;
        respawn.prota.position = new Vector3(respawn.next[2].position.x, respawn.next[2].position.y + 3, respawn.next[2].position.z);
        respawn.prota.rotation = respawn.next[2].rotation;
    }
}
