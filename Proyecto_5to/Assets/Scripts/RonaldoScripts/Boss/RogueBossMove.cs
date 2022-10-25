using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBossMove : MonoBehaviour
{
    public float MoveRango;
    public float FireRango;
    public float speed;

    public LayerMask LayerPlayer;
    public Transform PlayerPosition;

    bool Detect;
    bool FireDetect;
    bool Move = true;
    RogueBossFire Fire;

    void Start()
    {
        Fire = GetComponent<RogueBossFire>();
    }

    void Update()
    {
        Detect = Physics.CheckSphere(transform.position,MoveRango,LayerPlayer);
        FireDetect = Physics.CheckSphere(transform.position,FireRango, LayerPlayer);
        EnemyMovement();
    }

    void EnemyMovement()
    {

        
        if (FireDetect)
        {
            transform.LookAt(new Vector3(PlayerPosition.position.x, transform.position.y, PlayerPosition.position.z));
            if (Detect)
            {
                Fire.Active = false;

                if (Move)
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerPosition.position.x, transform.position.y, PlayerPosition.position.z), speed * Time.deltaTime);
                else if (!Move)
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerPosition.position.x, transform.position.y, PlayerPosition.position.z), 0 * Time.deltaTime);
            }
            else
            {
                Fire.Active = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, MoveRango);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, FireRango);
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
