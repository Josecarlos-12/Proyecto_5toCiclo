using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Mathematics;

public class MenuController : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 100;

    [Header("GamePlay Settings")]
    [SerializeField] private TMP_Text controllerSenTextValue = null;
    [SerializeField] private  Slider controllerSenSlider= null;
    [SerializeField] private int defaultSen = 4;
    public int mainControllerSen = 4;

    [Header("Toogle Settings")]
    [SerializeField] private Toggle invertYToggle = null;

    [Header("Confirmation")]
    [SerializeField] private GameObject comfirmationPrompt=null;

    [Header("Levels To Load")]
    public string _newGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    public void NewGameDialogYes( )
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogYes( ) 
    {
        if (PlayerPrefs.HasKey("SavedLevel")) 
        {
            levelToLoad = PlayerPrefs.GetString("SaveLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void ExitButton( )
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    { 
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0");
    }

    public void VolumeApply( )
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public void SetControllerSen(float sensitivity)
    {
        mainControllerSen = Mathf.RoundToInt(sensitivity);
        controllerSenTextValue.text = sensitivity.ToString("0");
    }

    public void GameplayApply( )
    {
        if ( invertYToggle.isOn )
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
        }

        PlayerPrefs.SetFloat("masterSen", mainControllerSen);
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string MenuType)
    {
        if(MenuType == "Audio" )
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0");
            VolumeApply();
        }

        if ( MenuType == "Gameplay" )
        {
            controllerSenTextValue.text = defaultSen.ToString("0");
            controllerSenSlider.value = defaultSen;
            mainControllerSen = defaultSen;
            invertYToggle.isOn = false;

            //INGRESAR VALORES A LA CONFIGURACIÓN A "defaultSen"

            GameplayApply( );
        }
    }

    public IEnumerator ConfirmationBox( )
    {
        comfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(1);
        comfirmationPrompt.SetActive(false);
    }
}