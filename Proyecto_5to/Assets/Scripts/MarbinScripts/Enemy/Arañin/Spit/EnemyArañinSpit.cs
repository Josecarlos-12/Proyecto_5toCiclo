using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyArañinSpit : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public LayerMask playerMask;
    public float AlertRange;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Destination();
    }

    private void Destination()
    {
        if (Physics.CheckSphere(transform.position, AlertRange, playerMask))
        {
            agent.destination = target.transform.position;
            //agent.destination = target.transform.position;
            //agent.stoppingDistance = 4;
        }
        else
        {
            anim.SetBool("Detected", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AlertRange);
    }

    public IEnumerator Follow()
    {
        yield return new WaitForSeconds(0.30f);
        
    }
}
