using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensibilityMouse : MonoBehaviour
{
    public Slider sensibility;
    public NewCamera sen;
    public float sliderValue;

    public void Start()
    {
        Cursor.visible = false;
        sensibility.value = PlayerPrefs.GetFloat("SenMouse", sliderValue);

    }



    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("SenMouse", sliderValue);
        //sen.mouseSensitivity = sensibility.value * 40;

    }


}
