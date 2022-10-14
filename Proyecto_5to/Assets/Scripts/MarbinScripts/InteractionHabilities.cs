using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHabilities : MonoBehaviour
{
    public bool touch;

    public GameObject[] options;
    public bool dash;
    public bool jumpTrue;
    public bool shootFast;
    public bool shootSlow;
    public Shield shield;
    public Life life;
    public Energy energy;

    public enum habilities
    {
        DobleSalto_Dash,
        TiposDeBala,
        Bala_Stats
    }
    public habilities hability;

    public Jump jump;

    public GameObject inte;
    public GameObject lightEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(touch && Input.GetKeyDown(KeyCode.E))
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            switch (hability)
            {
                case habilities.DobleSalto_Dash:
                    options[0].SetActive(true);
                    break;
                    case habilities.TiposDeBala:
                    options[1].SetActive(true);
                    break;
                case habilities.Bala_Stats:
                    options[2].SetActive(true);
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touch = false;
        }
    }

    public void DoubleJump()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        jumpTrue = true;
        options[0].SetActive(false);
        Destroy(inte);
    }

    public void Dash()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        dash = true;
        options[0].SetActive(false);
        Destroy(inte);
    }

    public void ShootFast()
    {
        shootFast = true;
        Cursor.visible = false;
        Time.timeScale = 1;
        options[1].SetActive(false);
        Destroy(inte);
    }

    public void ShootLow()
    {
        shootSlow = true;
        Cursor.visible = false;
        Time.timeScale = 1;
        options[1].SetActive(false);
        Destroy(inte);
    }

    public void OtherBullet()
    {
        Debug.Log("Bala");
        Cursor.visible = false;
        Time.timeScale = 1;
        options[2].SetActive(false);
        Destroy(inte);
    }

    public void Stats()
    {
        life.maxLife = 20;
        //energy.energyMax = 120;
        Cursor.visible = false;
        Time.timeScale = 1;
        options[2].SetActive(false);
        Destroy(inte);
    }
}
