using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RogueBossState : MonoBehaviour
{
    public float MaxHP = 100;
    float HP = 100;
    public float TimerRecharge = 15;
    public float MoveRango;
    public float FireRango;
    public Image HPbar;
    public LayerMask LayerPlayer;
    public Transform PlayerPosition;
    RogueBossFire Fire;
    RogueBossMove Move;
    RogueBossInvoke Invoker;
    public State state;

    bool Detect;
    bool FireDetect;

    float Timer;

    public enum State
    {
        run, shoot, idle, recharge, invoke
    }
    void Start()
    {
        HP = MaxHP;
        state = State.idle;
        Fire = GetComponent<RogueBossFire>();
        Move = GetComponent<RogueBossMove>();
        Invoker = GetComponent<RogueBossInvoke>();
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

            case State.invoke:
                Invoker.Active = true;
                break;

            case State.recharge:
                Recharge();
                break;
        }
        HPbar.fillAmount = HP / MaxHP;
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
                if(HP > 80)
                    state = State.shoot;
                else if(HP < 79)
                    state = State.invoke;

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
