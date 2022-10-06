using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public int routine;
    public float chronometer;
    public Quaternion angle;
    public float grade;

    public GameObject target;

    void Start()
    {
        target = GameObject.Find("Player");
    }

    public void Enemy_behaviour()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 10)
        {
            //Aqui la animacion de correr pasa a ser false 
            chronometer += 1 * Time.deltaTime;
            if (chronometer >= 4)
            {
                routine = Random.Range(0, 2);
                chronometer = 0;
            }
            switch (routine)
            {
                case 0:
                    //Aqui la animacion de caminar debe ser falso
                    break;

                case 1:
                    grade = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, grade, 0);
                    routine++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                    //Aqui la animacion de caminar cambiaria a verdadero 
                    break;
            }
        }
        else
        {
            var lookPos=target.transform.position-transform.position;
            lookPos.y=0;
            var rotation=Quaternion.LookRotation(lookPos);
            transform.rotation=Quaternion.RotateTowards(transform.rotation,rotation,3);
            //Aqui la animacion de caminar pasa a falso

            //Aqui la animaciond de correr cambia a verdadero
            transform.Translate(Vector3.forward*4*Time.deltaTime);
        }
    }

    void Update()
    {
        Enemy_behaviour();
    }
}
