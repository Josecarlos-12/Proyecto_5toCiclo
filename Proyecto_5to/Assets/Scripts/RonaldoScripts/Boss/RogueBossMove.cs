using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBossMove : MonoBehaviour
{
    public bool Active;
    public float speed;
    public float time_follow = 10;
    public float damage;
    Transform PlayerPosition;
    RogueBossState pp;
    bool Move = true;
    float timer = 0;
    private void Start()
    {
        pp = GetComponent<RogueBossState>();
    }

    void Update()
    {
        EnemyMovement();
        PlayerPosition = pp.PlayerPosition;
    }

    void EnemyMovement()
    {
        
        if (timer > time_follow)
        {
            pp.state = RogueBossState.State.recharge;
            timer = 0;
            Active = false;
        }
        else
        {
            if (Active)
            {
                timer += Time.deltaTime;
                transform.LookAt(new Vector3(PlayerPosition.position.x, transform.position.y, PlayerPosition.position.z));

                if (Move)
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerPosition.position.x, transform.position.y, PlayerPosition.position.z), speed * Time.deltaTime);
                else if (!Move)
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerPosition.position.x, transform.position.y, PlayerPosition.position.z), 0 * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Move = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Move = true;
        }
    }
}
