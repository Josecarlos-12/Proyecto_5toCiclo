using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoubleJumpActivation : MonoBehaviour
{
    public Jump jump;
    public GameObject wallJump;
    public GameObject dj;

    public TextMeshProUGUI text;
    public GameObject textObject;
    public DesactiveText des;
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Player") )
        {
            des.into = true;
            text.text = "Has obtenido Doble salto (Presiona 2 veces barra espaciadora para utilizar)";
            jump.jumpOne = false;
            jump.jumpTwo = true;
            wallJump.SetActive(true);
            dj.SetActive(false);
            textObject.SetActive(true);
        }
    }

    public void DJump( )
    {
        jump.jumpOne = false;
        jump.jumpTwo = true;
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public IEnumerator FalseText()
    {
        yield return new WaitForSeconds(3);
        textObject.SetActive(false);
    }

}
