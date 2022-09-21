using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Intangible : MonoBehaviour
{
    public Renderer prota;
    public Life life;
    public bool respawn;

    public Transform positionProta;

    private void Start()
    {
        positionProta.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            positionProta.position = new Vector3(positionProta.position.x, 9);
            life.enabled = false;
            prota.material.color = Color.green;
            StartCoroutine(Return());
            respawn = true;
        }
    }



    public IEnumerator Return()
    {
        yield return new WaitForSeconds(5);
        prota.material.color = Color.white;
        life.enabled = true;
        respawn = false;
    }
}
