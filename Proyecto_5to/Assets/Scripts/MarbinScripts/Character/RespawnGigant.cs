using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnGigant : MonoBehaviour
{
    public Transform prota;
    public Transform cameraPosition;
    public Transform floor;
    public Transform[] next;


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
            
            prota.rotation = Quaternion.Euler(0,-180,0);
            //cameraPosition.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (other.gameObject.name == "NextThree")
        {
            prota.position = new Vector3(next[1].position.x, next[1].position.y + 3, next[1].position.z);
            prota.rotation = next[1].rotation;

            
            // cameraPosition.rotation = Quaternion.Euler(0, 0, 0);
            //StartCoroutine(Bug());
        }
        else if (other.gameObject.name == "NextFour")
        {
            prota.position = new Vector3(next[2].position.x, next[2].position.y + 3, next[2].position.z);
            prota.rotation = next[2].rotation;

            //prota.position = new Vector3(next[4].position.x, next[4].position.y + 3, next[4].position.z);
            //prota.rotation = next[4].rotation;
            //cameraPosition.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion

       

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            prota.position = new Vector3(next[1].position.x, next[1].position.y + 3, next[1].position.z);
            prota.rotation = next[1].rotation;
        }

        #region Respawn
        if (other.gameObject.CompareTag("checkpoint"))
        {
            Debug.Log("Check");
            lastCheckPoint.position = other.transform.position;
            lastCheckPoint.rotation=other.transform.rotation;
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Respawn");
            prota.position= lastCheckPoint.transform.position;
            prota.rotation = lastCheckPoint.rotation;
            //prota.rotation = Quaternion.Euler(0, -180, 0);
            //cameraPosition.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion
    }

    public IEnumerator Bug()
    {
        yield return new WaitForSeconds(3);
        prota.position = new Vector3(next[2].position.x, next[2].position.y + 3, next[2].position.z);
        prota.rotation = next[2].rotation;
    }


}
