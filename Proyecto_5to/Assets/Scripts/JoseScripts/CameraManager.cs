using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;
    public int camMode;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (camMode == 1)
            {
                camMode = 0;
            }

            /*if (camMode == 2)
            {
                camMode = 0;
            }*/

            else
            {
                camMode += 1;
            }
            StartCoroutine(camChange());
        }

        IEnumerator camChange()
        {
            yield return new WaitForSeconds(0.01f);
            if (camMode == 0)
            {
                cameras[0].SetActive(true);
                cameras[1].SetActive(false);
            }
            if (camMode == 1)
            {
                cameras[0].SetActive(false);
                cameras[1].SetActive(true);
            }
            /*if (camMode == 2)
            {
                
                cameras[1].SetActive(false);
                cameras[2].SetActive(true);
            }*/
        }
    }
}
