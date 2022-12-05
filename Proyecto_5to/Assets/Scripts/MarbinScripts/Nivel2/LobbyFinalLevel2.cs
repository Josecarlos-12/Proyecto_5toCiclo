using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class LobbyFinalLevel2 : MonoBehaviour
{
    public GameObject prota, cam;
    public bool open;
    public int count;
    public RespawnGigant res;
    public Animator doorDown;
    public Collider col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerEnter(Collider other)
    {      
        if (count < 3)
            count++;

        if (count == 1)
            BoosCamera();
        if (count == 2 || count == 3)
        {
            col.enabled = true;
            res.prota.position = new Vector3(res.next[5].position.x, res.next[5].position.y + 3, res.next[5].position.z);
            res.prota.rotation = res.next[5].rotation;
        }
    }


    public void BoosCamera()
    {
        prota.SetActive(false);
        cam.SetActive(true);
        doorDown.SetBool("Open", true);
        StartCoroutine(Camerafalse());
    }

    public IEnumerator Camerafalse()
    {
        yield return new WaitForSeconds(3);
        prota.SetActive(true);
        cam.SetActive(false);
    }
}
