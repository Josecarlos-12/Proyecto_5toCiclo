using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool isPaused=false;
    public GameObject pauseMenuUI;
    public Experience option;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                option.options = false;
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
                
            }
            else
            {
                option.options = true;
                PauseGame();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;

        AudioSource[] audio= FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audio)
        {
            a.UnPause();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        
        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        
        foreach (AudioSource a in audio)
        {
            a.Pause();
        }
    }
}
