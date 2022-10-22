using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject cameraOne, cameraTwo;
    // Start is called before the first frame update
    void Start()
    {
        cameraOne.SetActive(true);
        cameraTwo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cameraOne.SetActive(false);
            cameraTwo.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            cameraOne.SetActive(true);
            cameraTwo.SetActive(false);
        }
    }
}
