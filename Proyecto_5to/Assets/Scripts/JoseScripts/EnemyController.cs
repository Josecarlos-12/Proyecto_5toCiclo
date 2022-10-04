using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float starWaitTime = 4;
    public float timeToRotate = 2;
    public float speedWalk = 6;
    public float speedRun = 9;

    public float viewRadius=15;
    public float viewAngle =90;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public float meshResolution=1f;
    public int edgeIterations=4;
    public float edgeDistance= 0.5f;

    public Transform[]waypoints;
    int m_CurrentWaypointIndex;

    Vector3 playerLastPosition = Vector3.zero;
    Vector3 m_PlayerPosition;

    float m_WaitTime;
    float m_TimeToRotate;
    bool m_PlayerInRange;
    bool m_PlayerNear;
    bool m_IsPatrol;
    bool m_CaughtPlayer;
    // Start is called before the first frame update
    void Start()
    {
        m_PlayerPosition=Vector3.zero;
        m_IsPatrol=true;
        m_CaughtPlayer=false;
        m_PlayerInRange=false;
        m_WaitTime = starWaitTime;
        m_TimeToRotate=timeToRotate;

        m_CurrentWaypointIndex=0;
        navMeshAgent=GetComponent<NavMeshAgent>();

        navMeshAgent.isStopped=false;
        navMeshAgent.speed=speedWalk;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
