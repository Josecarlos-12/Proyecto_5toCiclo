using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveEnemy : MonoBehaviour
{
    public RobotinShoot robot;
    public GameObject miniBoss,active;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            robot.enabled= false;
            StartCoroutine(Destroy());
        }
    }

    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(miniBoss);
        Destroy(active);
    }
}
