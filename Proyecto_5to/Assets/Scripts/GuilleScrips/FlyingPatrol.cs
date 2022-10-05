using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingPatrol : MonoBehaviour
{
    public Rigidbody platformRB;
    public Transform[] platformPosition;
    public float platformSpeed;
   
    private int actualPosition = 0;
    private int nextPosition = 1;
    
    public bool moveToTheNext = true;
    public float waitTime;

    public Transform robot;

    public enum Walk
    {
        Walking,
        Rotation
    }
    public Walk walk = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (walk)
        {
            case Walk.Walking:
                MovePlatform();
                break;
                case Walk.Rotation:
                Rotation();
                break;
        }
        
    }

    void Rotation()
    {
        robot.Rotate(0, platformSpeed*Time.deltaTime, 0);
    }

    void MovePlatform()
    {
        if (moveToTheNext)
        {
            StopCoroutine(WaitForMove(0));
            platformRB.MovePosition(Vector3.MoveTowards(platformRB.position, platformPosition[nextPosition].position, platformSpeed * Time.deltaTime));
        }

        if(Vector3.Distance(platformRB.position, platformPosition[nextPosition].position)<=0)
        {
            StartCoroutine(WaitForMove(waitTime));
            actualPosition= nextPosition;
            nextPosition++;

            if(nextPosition>platformPosition.Length-1)
            {
                nextPosition=0;
            }
        }
    }

    IEnumerator WaitForMove(float time)
    {
        moveToTheNext = false;
        yield return new WaitForSeconds(time);
        moveToTheNext=true;
    }
}
