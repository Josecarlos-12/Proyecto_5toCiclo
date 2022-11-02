using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DashActivation : MonoBehaviour
{
    //public bool into;
    public DashController dash;

    public GameObject wallDash, dashL;

    public TextMeshProUGUI text;
    public GameObject textObject;

    public DesactiveText des;

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Player") )
        {
            des.into = true;
            text.text = "Has obtenido Impulso (Shift para utilizar))";
            textObject.SetActive(true);
            dash.canDash = true;
            dashL.SetActive(false);
            wallDash.SetActive(true);
            textObject.SetActive(true);
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

    public IEnumerator FalseText()
    {
        yield return new WaitForSeconds(3);
        textObject.SetActive(false);
    }

}
