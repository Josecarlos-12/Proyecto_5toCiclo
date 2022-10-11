using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnGigant : MonoBehaviour
{
    public GameObject module;
    public Transform prota;
    public Transform floor;
    public Transform[] next;
    public Transform[] respawn;
    public GameObject time;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Module"))
        {
            module = other.gameObject;
        }
        if (other.gameObject.CompareTag("Gigant"))
        {
            prota.position=new Vector3(floor.position.x, floor.position.y+5, floor.position.z);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            prota.position=new Vector3(module.transform.position.x, module.transform.position.y+3, module.transform.position.z);
        }

        #region Next
        if (other.gameObject.name == "NextOne")
        {
            prota.position=new Vector3(next[0].position.x, next[0].position.y+3, next[0].position.z);
        }
        if (other.gameObject.name == "NextTwo")
        {
            prota.position = new Vector3(next[1].position.x, next[1].position.y + 3, next[1].position.z);
        }
        if (other.gameObject.name == "NextThree")
        {
            prota.position = new Vector3(next[2].position.x, next[2].position.y + 3, next[2].position.z);            
        }
        if (other.gameObject.name == "NextFour")
        {
            prota.position = new Vector3(next[5].position.x, next[5].position.y + 3, next[5].position.z);
            StartCoroutine(Bug());
        }
        if (other.gameObject.name == "NextFive")
        {
            time.SetActive(true);
            prota.position = new Vector3(next[4].position.x, next[4].position.y + 3, next[4].position.z);
        }
        if (other.gameObject.name == "NextSix")
        {
            time.SetActive(false);
            prota.position = new Vector3(next[6].position.x, next[6].position.y + 3, next[6].position.z);
        }
        #endregion

        #region Respawn
        if (other.gameObject.name == "Respawn0")
        {
            prota.position = new Vector3(respawn[0].position.x, respawn[0].position.y + 3, respawn[0].position.z);
        }
        if (other.gameObject.name == "Respawn1")
        {
            prota.position = new Vector3(respawn[1].position.x, respawn[1].position.y + 3, respawn[1].position.z);
        }
        if (other.gameObject.name == "Respawn2")
        {
            prota.position = new Vector3(respawn[2].position.x, respawn[2].position.y + 3, respawn[2].position.z);
        }
        if (other.gameObject.name == "Respawn3")
        {
            prota.position = new Vector3(respawn[3].position.x, respawn[3].position.y + 3, respawn[3].position.z);
        }
        if (other.gameObject.name == "Respawn4")
        {
            prota.position = new Vector3(respawn[4].position.x, respawn[4].position.y + 3, respawn[4].position.z);
        }
        if (other.gameObject.name == "Respawn5")
        {
            prota.position = new Vector3(respawn[5].position.x, respawn[5].position.y + 3, respawn[5].position.z);
        }
        if (other.gameObject.name == "Respawn6")
        {
            prota.position = new Vector3(respawn[6].position.x, respawn[6].position.y + 3, respawn[6].position.z);
        }
        #endregion
    }

    public IEnumerator Bug()
    {
        yield return new WaitForSeconds(3);
        prota.position = new Vector3(next[3].position.x, next[3].position.y + 3, next[3].position.z);
    }
}
