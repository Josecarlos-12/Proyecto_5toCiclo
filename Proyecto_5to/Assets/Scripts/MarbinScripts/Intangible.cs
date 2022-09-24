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


    public void Respawn()
    {
        positionProta.position = new Vector3(positionProta.position.x, transform.position.y+9, positionProta.position.z);
        life.enabled = false;
        prota.material.color = Color.green;
        StartCoroutine(Return());
        respawn = true;
    }
    public void RespawnTwo()
    {
        life.enabled = false;
        prota.material.color = Color.green;
        StartCoroutine(Return());
        respawn = true;
    }


    public IEnumerator Return()
    {
        yield return new WaitForSeconds(5);
        prota.material.color = life.color;
        life.enabled = true;
        respawn = false;
    }
}
