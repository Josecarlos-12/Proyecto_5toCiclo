using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public float rangoDeAlerta;
    public LayerMask PlayerMask;
    public Transform Player;
    public float speed;
    bool Alert;
    public bool move;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        Alert = Physics.CheckSphere(transform.position, rangoDeAlerta, PlayerMask);

        if (Alert == true)
        {
            Vector3 posPlayer = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, transform.position.y, Player.position.z), speed * Time.deltaTime);
        }
              
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            move = false;
            speed = 0;
        }


    }

    void MovePlatform()
    {
        if (move)
        {
            //StopCoroutine(WaitForMove());

        }

        else
        {
            Time.timeScale = 1;
            StartCoroutine(WaitForMove());

        }
    }

    IEnumerator WaitForMove()
    {

        yield return new WaitForSeconds(waitTime);
        move = true;
        speed = 5;
    }


}
