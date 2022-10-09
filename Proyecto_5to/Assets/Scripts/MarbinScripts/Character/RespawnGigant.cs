using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnGigant : MonoBehaviour
{
    public GameObject module;
    public Transform prota;
    public Transform floor;
    public Transform[] next;

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
            prota.position = new Vector3(next[4].position.x, next[4].position.y + 3, next[4].position.z);
        }
        if (other.gameObject.name == "NextSix")
        {
            prota.position = new Vector3(next[6].position.x, next[6].position.y + 3, next[6].position.z);
        }
        #endregion

    }

    public IEnumerator Bug()
    {
        yield return new WaitForSeconds(3);
        prota.position = new Vector3(next[3].position.x, next[3].position.y + 3, next[3].position.z);
    }
}
