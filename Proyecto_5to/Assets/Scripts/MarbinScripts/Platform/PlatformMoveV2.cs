using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveV2 : MonoBehaviour
{
    public Transform p1, p2;

    public float speedNormal = 2;
    public float speedMax = 2;

    public int waypointsIndex = 0;

    public enum Platform
    {
        uno,
        dos
    }

    public Platform platform;

    void Update()
    {
        switch (platform)
        {
            case Platform.uno:
                MovePlatform();
                break;
            case Platform.dos:
            MoveTwo();
                break;
        }
    }

    public void MovePlatform()
    {
        
        if (Vector3.Distance(transform.position, p1.transform.position) < 0.1f)
        {
            waypointsIndex = 2;            
        }
        if (Vector3.Distance(transform.position, p2.transform.position) < 0.1f)
        {
            waypointsIndex = 1;            
        }

        if (waypointsIndex == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, p1.transform.position, speedMax * Time.deltaTime);
        }
        else if (waypointsIndex == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, p2.transform.position, speedNormal * Time.deltaTime);
        }
    }

    public void MoveTwo()
    {
        if (Vector3.Distance(transform.position, p1.transform.position) < 0.1f)
        {
            waypointsIndex = 2;
        }
        if (Vector3.Distance(transform.position, p2.transform.position) < 0.1f)
        {
            waypointsIndex = 1;
        }

        if (waypointsIndex == 1)
        {
            speedMax = 0;
            speedNormal = 0;
            StartCoroutine(T1());
        }
        else if (waypointsIndex == 2)
        {
            speedMax = 0;
            speedNormal = 0;
            StartCoroutine(T2());
        }
    }

    public IEnumerator T1()
    {
        yield return new WaitForSeconds(3);
        speedMax = 5;
        transform.position = Vector3.MoveTowards(transform.position, p1.transform.position, speedMax * Time.deltaTime);
        
    }

    public IEnumerator T2()
    {
        yield return new WaitForSeconds(3);
        speedNormal = 15;
        transform.position = Vector3.MoveTowards(transform.position, p2.transform.position, speedNormal * Time.deltaTime);
    }

}
