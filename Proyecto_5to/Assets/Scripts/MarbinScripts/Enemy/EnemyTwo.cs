using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTwo : MonoBehaviour
{  

    [SerializeField] FieldOfView fieldOfView;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shoot;

    private void Start()
    {
    }

    private void Update()
    {
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetDirection(transform.forward);

        Destination();

       // if (agent.remainingDistance <= .1f)
         //   transform.rotation = Quaternion.Slerp(transform.rotation, startRotation, Time.deltaTime * smooothRotationTime);
    }

    private void Destination()
    {
        if (fieldOfView.IsTarget)
        {
            Debug.Log("Shot");
            Instantiate(bullet,shoot.position,shoot.rotation);
        }
    }
}
