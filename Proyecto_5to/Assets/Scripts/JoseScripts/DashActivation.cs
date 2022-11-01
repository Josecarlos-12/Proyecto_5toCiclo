using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashActivation : MonoBehaviour
{
    //public bool into;
    public DashController dash;

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Player") )
        {
            dash.canDash = true;
            Destroy(gameObject);
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if ( other.gameObject.CompareTag("Player") )
        {
            into = false;
        }
    }*/

    public void Dash( )
    {
        dash.canDash = true;
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
