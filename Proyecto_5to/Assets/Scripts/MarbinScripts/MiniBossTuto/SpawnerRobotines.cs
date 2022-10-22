using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRobotines : MonoBehaviour
{
    public GameObject robot;
    public Transform point, pointA;

    public float time;
    public float maxTime;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(robot, point.position, Quaternion.identity);
        Instantiate(robot, pointA.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > maxTime)
        {
            time = 0;
            Instantiate(robot, point.position, Quaternion.identity);
            Instantiate(robot, pointA.position, Quaternion.identity);
        }
            
        
    }
}
