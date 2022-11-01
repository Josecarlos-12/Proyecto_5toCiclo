using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverr : MonoBehaviour
{
    public Life life;
    public GameObject over;
    public bool retu;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life.recover <= 0 && !retu)
        {
            over.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
    }

    public void Return()
    {
        retu = true;
        Debug.Log("Return");
        //over.SetActive(false);
        Time.timeScale = 1; 
        SceneManager.LoadScene("TestingSceneNivel1");
        Debug.Log(Time.timeScale);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
        //StartCoroutine(ReturnFalse());
    }

    public IEnumerator ReturnFalse()
    {
        yield return null;
        SceneManager.LoadScene("TestingSceneNivel1");
    }
}
