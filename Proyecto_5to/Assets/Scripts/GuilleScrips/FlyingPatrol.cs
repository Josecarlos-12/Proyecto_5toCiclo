using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
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
