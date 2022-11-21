using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public AudioSource audioSource;
    public GameObject gText;
    public TextMeshProUGUI text;
    [TextArea(8,8)]
    public string[] sText;
    public float[] time;
    private void Start()
    {
        //PlayerPrefs.SetInt("DoubleJump", 0);
        //PlayerPrefs.SetInt("Dash", 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            PlayerPrefs.SetInt("DoubleJump", 0);
            PlayerPrefs.SetInt("Dash", 0);
            jump.maxJumpCount = 1;
            jump.jumpTwo = false;
            jump.jumpOne = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "JumpOne")
        {
            jump.jumpOne = true;
        }
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
            other.GetComponent<Collider>().enabled = false;
            sword.canAtack = true;
            audioSource.Play();
            StartCoroutine(NexDialogue());
        }
    }

    public IEnumerator NexDialogue()
    {
        yield return new WaitForSeconds(time[0]);
        gText.SetActive(true);
        text.text = sText[0];
        yield return new WaitForSeconds(time[1]);
        text.text = sText[1];
        yield return new WaitForSeconds(time[2]);
        text.text = sText[2];
        yield return new WaitForSeconds(time[3]);
        gText.SetActive(false);
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
