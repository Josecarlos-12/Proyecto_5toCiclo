using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEditor.SceneView;

public class CameraBaind : MonoBehaviour
{
    public GameObject camera1, camera2;
    public GameObject pointer;
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.Confined;
        Cursor.visible=false;
        pointer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Point();
    }

    public void Point()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            weapon.enabled = true;
            pointer.SetActive(true);
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            weapon.enabled = false;
            pointer.SetActive(false);
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
    }
}
