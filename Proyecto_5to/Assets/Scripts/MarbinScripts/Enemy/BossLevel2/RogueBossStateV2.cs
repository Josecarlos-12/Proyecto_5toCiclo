using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RogueBossStateV2 : MonoBehaviour
{
    public float MaxHP = 100;
    float HP = 100;
    public float TimerRecharge = 15;
    public float MoveRango;
    public float MeleeRango;
    public float FireRango;

    public Image HPbar;
    public LayerMask LayerPlayer;
    public Transform PlayerPosition;
    public GameObject ShieldPrefab;

    RogueBossFireV2 Fire;
    RogueBossMoveV2 Move;
    RogueBossInvokeV2 Invoker;
    RogueBossMeleeV2 Melee;
    RogueBossShieldV2 Shield;

    public State state;

    bool Detect;
    bool FireDetect;
    bool MeleeDetect;
    bool ShieldActives;

    float Timer;

    public Renderer render;
    public Sword sword;
    public Bullet bullet, laser;
    public int count;

    public enum State
    {
        run, shoot, idle, recharge, invoke
    }
    void Start()
    {
        HP = MaxHP;
        state = State.idle;
        Fire = GetComponent<RogueBossFireV2>();
        Move = GetComponent<RogueBossMoveV2>();
        Invoker = GetComponent<RogueBossInvokeV2>();
        Melee = GetComponent<RogueBossMeleeV2>();
    }
    void Update()
    {
        Death();
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

        Detect = Physics.CheckSphere(transform.position, MoveRango, LayerPlayer);
        if (MeleeDetect)
        {
            Melee.Active = true;
        }
        GenerateShield();
    }

    void PlayerDetect()
    {
        FireDetect = Physics.CheckSphere(transform.position, FireRango, LayerPlayer);
        MeleeDetect = Physics.CheckSphere(transform.position + new Vector3(0f, -1f, 0f), MeleeRango, LayerPlayer);

        if (FireDetect)
        {
            if (Detect && Fire.Active == false)
            {
                state = State.run;
            }
            else if (!Detect)
            {
                if (HP > 80)
                    state = State.shoot;
                else if (HP < 79)
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

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, MeleeRango);
    }

    void GenerateShield()
    {
       Shield.Shield_1 = true;

        if (HP < 50)
          Shield.Shield_2 = true;

        ShieldActives = Shield.DefenseActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") && !ShieldActives)
        {
            render.material.color = Color.red;
            HP -= bullet.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("Sword") && !ShieldActives)
        {
            render.material.color = Color.red;
            HP -= sword.damage;
            Debug.Log("Macheteo");
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("LaserProta") && !ShieldActives)
        {
            render.material.color = Color.red;
            HP -= laser.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.name == "WaveProta" && !ShieldActives)
        {
            if (count < 3)
            {
                count++;
            }
            if (count == 1)
            {
                StartCoroutine(ChangeColor());
                HP -= 60;
            }
        }
    }

    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        render.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        count = 0;
    }

    void Death()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
