using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoInteractionsCanvas : MonoBehaviour
{
    public GameObject options;
    public bool into;
    public Jump jump;
    public DashController dash;

    private void Update()
    {
        Press();
    }

    public void Press()
    {
        if (Input.GetKeyDown(KeyCode.E) && into==true)
        {
            options.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            into = false;
        }
    }

    public void DoubleJump()
    {
        jump.jumpOne = false;
        jump.jumpTwo = true;
        options.SetActive(false);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void Dash()
    {
        dash.canDash = true;
        options.SetActive(false);
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
