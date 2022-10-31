using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool isPaused=false;
    public GameObject pauseMenuUI;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
                
            }
            else
            {
                PauseGame();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void ResumeGame()
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

    void PauseGame()
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
