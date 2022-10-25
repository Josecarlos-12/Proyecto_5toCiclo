using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnGigant : MonoBehaviour
{
    public GameObject module;
    public Transform prota;
    public Transform floor;
    public Transform[] next;
    public GameObject time;


    public Transform lastCheckPoint;

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Module"))
        {
            module = other.gameObject;
        }*/
        if (other.gameObject.CompareTag("Gigant"))
        {
            prota.position=new Vector3(floor.position.x, floor.position.y+5, floor.position.z);
        }
        /*if (other.gameObject.CompareTag("Enemy"))
        {
            prota.position=new Vector3(module.transform.position.x, module.transform.position.y+3, module.transform.position.z);
        }*/

        #region Next

        if (other.gameObject.name == "NextTwo")
        {
            prota.position = new Vector3(next[1].position.x, next[1].position.y + 3, next[1].position.z);
        }
        if (other.gameObject.name == "NextThree")
        {
            prota.position = new Vector3(next[3].position.x, next[3].position.y + 3, next[3].position.z);
            StartCoroutine(Bug());
        }
        if (other.gameObject.name == "NextFour")
        {
            prota.position = new Vector3(next[4].position.x, next[4].position.y + 3, next[4].position.z);
        }
        #endregion

       

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            prota.position = new Vector3(next[1].position.x, next[1].position.y + 3, next[1].position.z);
        }

        #region Respawn
        if (other.gameObject.CompareTag("checkpoint"))
        {
            lastCheckPoint.position = other.transform.position;
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            prota.position= lastCheckPoint.transform.position;
        }
        #endregion
    }

    public IEnumerator Bug()
    {
        yield return new WaitForSeconds(3);
        prota.position = new Vector3(next[2].position.x, next[2].position.y + 3, next[2].position.z);
    }


}
