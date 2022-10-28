using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBossState : MonoBehaviour
{
    public float TimerRecharge = 15;
    public float MoveRango;
    public float FireRango;
    public LayerMask LayerPlayer;
    public Transform PlayerPosition;
    RogueBossFire Fire;
    RogueBossMove Move;
    public State state;

    bool Detect;
    bool FireDetect;

    float Timer;

    public enum State
    {
        run, shoot, idle, recharge
    }
    void Start()
    {
        state = State.idle;
        Fire = GetComponent<RogueBossFire>();
        Move = GetComponent<RogueBossMove>();
    }
    void Update()
    {
        switch (state)
        {
            case State.idle:
                PlayerDetect();
                break;

            case State.run:
                Move.Active = true;
                break;

            case State.shoot:
                Fire.Active = true;
                break;

            case State.recharge:
                Recharge();
                break;
        }
    }

    void PlayerDetect()
    {
        Detect = Physics.CheckSphere(transform.position, MoveRango, LayerPlayer);
        FireDetect = Physics.CheckSphere(transform.position, FireRango, LayerPlayer);

        if (FireDetect)
        {
            if (Detect && Fire.Active == false)
            {
                state = State.run;
            }
            else if (!Detect)
            {
                state = State.shoot;
            }
        }
        else
        {
            state = State.idle;
        }
    }

    void Recharge()
    {
        Timer += Time.deltaTime;
        if (Timer > TimerRecharge)
        {
            state = State.idle;
            Timer = 0;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, MoveRango);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, FireRango);
    }
}
