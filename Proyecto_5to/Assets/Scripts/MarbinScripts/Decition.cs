using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decition : MonoBehaviour
{
    public GameObject enemy;
    public GameObject canva;
    public GameObject next;
    public Material colorBullet;
    public Color color;
    public bool ene;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        //colorBullet.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
     
        if(enemy == null)
        {
            count++;
            if(count == 1)
            {
                next.SetActive(true);
                Cursor.visible = true;
                canva.SetActive(true);
                Time.timeScale = 0;
            }
            ene = true;
            
        }
        if (ene)
        {
            
        }
    }


    public void Green()
    {
        Cursor.visible = false;
        ene = false;
        canva.SetActive(false);
        Time.timeScale = 1;
        colorBullet.color = Color.green;
    }

    public void Blue()
    {
        Cursor.visible = false;
        ene = false;
        canva.SetActive(false);
        Time.timeScale = 1;
        colorBullet.color = Color.blue;
    }
}
