using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;

    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
