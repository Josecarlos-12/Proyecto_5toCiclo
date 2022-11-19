using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnGigant : MonoBehaviour
{
    public Transform prota;
    public Transform cameraPosition;
    public Transform floor;
    public Transform[] next;


    public Transform lastCheckPoint;


    public Energy ener;
    private void Update()
    {
        Inputs();
    }


    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Module"))
        {
            module = other.gameObject;
        }*/
       
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
        else if (other.gameObject.name == "NextFive")
        {
            prota.position = new Vector3(next[3].position.x, next[3].position.y + 3, next[3].position.z);
            prota.rotation = next[3].rotation;
        }
      
        #endregion



        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            prota.position = new Vector3(next[1].position.x, next[1].position.y + 3, next[1].position.z);
            prota.rotation = next[1].rotation;
        }

        #region Nexts Levels
        if (other.gameObject.name == "NextLoby")
        {
            SceneManager.LoadScene("LobbyScene");
        }
        if (other.gameObject.name == "LevelOne")
        {
            SceneManager.LoadScene("TestingSceneNivel1");
        }
        #endregion

        #region Respawn
        if (other.gameObject.CompareTag("checkpoint"))
        {
            Debug.Log("Check");
            lastCheckPoint.position = other.transform.position;
            lastCheckPoint.rotation=other.transform.rotation;
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            ener.energy = ener.energyMax;
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

    public void Inputs()
    {
        if ( Input.GetKeyDown(KeyCode.F1))
        {
            prota.position = new Vector3(next[0].position.x, next[0].position.y + 3, next[0].position.z);
            prota.rotation = next[0].rotation;
        }
        else if ( Input.GetKeyDown(KeyCode.F2))
        {
            prota.position = new Vector3(next[1].position.x, next[1].position.y + 3, next[1].position.z);
            prota.rotation = next[1].rotation;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            prota.position = new Vector3(next[2].position.x, next[2].position.y + 3, next[2].position.z);
            prota.rotation = next[2].rotation;
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            prota.position = new Vector3(next[3].position.x, next[3].position.y + 3, next[3].position.z);
            prota.rotation = next[3].rotation;
        }
    }
}
