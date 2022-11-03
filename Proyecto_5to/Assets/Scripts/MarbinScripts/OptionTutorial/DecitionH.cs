using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DecitionH : MonoBehaviour
{
    public GameObject dJump, dash, boxD,boxJ;
    public int count;
    public Transform prota, init;
    public Collider coll, coll2;

    public GameObject wallJ, wallD, lightJ, lihtD;

    public Jump jumpp;
    public DashController dashC;
    public enum Habilite
    {
        DJUMP,
        DASH
    }
    public Habilite habilite;

    private void Start()
    {
        PlayerPrefs.SetInt("DoubleJump", 0);
        PlayerPrefs.SetInt("Dash", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            switch (habilite)
            {
                case Habilite.DJUMP:
                    if (count < 3)
                        count++;

                    if (count == 1)
                    {
                        
                        coll.enabled = false;
                        coll2.enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        Time.timeScale = 0;
                        dJump.SetActive(true);
                    }                    
                    break;
                case Habilite.DASH:
                    
                    if (count < 3)
                        count++;

                    if (count == 1)
                    {
                        
                        
                        coll.enabled = false;
                        coll2.enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        Time.timeScale = 0;
                        dash.SetActive(true);
                    }
                    break;

            }
            
            
        }
    }



    public void YesDoJumo()
    {
        PlayerPrefs.SetInt("DoubleJump", 1);
        boxJ.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        dJump.SetActive(false);
        Destroy(gameObject);
    }

    public void Dash()
    {
        PlayerPrefs.SetInt("Dash", 1);
        boxD.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        dash.SetActive(false);
        Destroy(gameObject);
    }

    public void Return()
    {
        jumpp.jumpOne = true;
        jumpp.jumpTwo = false;
        jumpp.jumpsRemaining = 1;
        jumpp.maxJumpCount = 1;


        dashC.canDash = false;

        count = 0;
        coll.enabled = true;
        coll2.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        prota.position = init.position;
        wallJ.SetActive(false);
        wallD.SetActive(false);
        lightJ.SetActive(true);
        lihtD.SetActive(true);

        dJump.SetActive(false);
        dash.SetActive(false);
    }
}
