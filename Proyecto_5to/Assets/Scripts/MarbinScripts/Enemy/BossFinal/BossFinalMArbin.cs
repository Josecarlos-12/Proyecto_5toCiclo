using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossFinalMArbin : MonoBehaviour
{
    [Header("Movimiento")]
    public NavMeshAgent agent;
    public float attack, noMove;

    [Header("Attack")]
    public GameObject prota;
    public float size;
    public GameObject swordWave;
    public Transform pointShoot;
    public Animator anim;
    public bool wave, combo, followCombo, inCircle, animAttack;
    public float time, maxTime, maxTime2;
    public GameObject SwordsEnemy;

    [Header("Life")]
    public float life = 200;
    public Renderer material;
    public Sword sword;
    public Bullet bullet, laser;
    public GameObject allContainer;

    public GameObject bulleta;

    // Start is called before the first frame update
    void Start()
    {
     anim=GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        Bullet();

        /*if (followCombo)
        {
           Follow();
           Combo();
           AnimTrue();
        }

        SwordWave();
        Life();

        SwordsInCircle();*/
    }

    public void Bullet()
    {
        if (Vector3.Distance(transform.position, prota.transform.position) < size)
        {
        }
    }

    public void Follow()
    {
        if (Vector3.Distance(transform.position, prota.transform.position) < size)
        {
            transform.LookAt(new Vector3(prota.transform.position.x, transform.position.y, prota.transform.position.z));
            agent.destination = prota.transform.position;
            agent.speed = 15;
            agent.acceleration = 30;
        }
        else
        {

        }
    }

    public void Combo()
    {        
        if (Vector3.Distance(transform.position, prota.transform.position) < attack)
        {
            transform.LookAt(new Vector3(prota.transform.position.x, transform.position.y, prota.transform.position.z));
            Debug.Log("Attack Combo");
            if (animAttack)
            {
                anim.SetBool("Combo", true);
            }
            else
            {
                anim.SetBool("Combo", false);
            }
            
            //agent.speed = 0;
            //agent.acceleration = 0;
            //agent.destination = transform.position;
            

        }
        else
        {
            anim.SetBool("Combo", false);
            
        }

        if (Vector3.Distance(transform.position, prota.transform.position) < noMove)
        {
            agent.acceleration = 0;
            agent.speed = 0;
            agent.destination = transform.position;
            combo = true;
        }
        else
        {
            combo = false;
        }
    }

    public void AnimFalse()
    {
        animAttack = false;
    }

    public void AnimTrue()
    {
        if (!animAttack)
        {
            time = time + Time.deltaTime;
            if (time > maxTime)
            {
                time = 0;
                animAttack = true;
            }
        }
    }

    public void SwordWave()
    {
        if (!wave)
        {
            if (Vector3.Distance(transform.position, prota.transform.position) < size)
            {
                transform.LookAt(new Vector3(prota.transform.position.x, transform.position.y, prota.transform.position.z));
                anim.SetBool("Attack", true);
            }
            else
            {
                anim.SetBool("Attack", false);
            }
        }
       
    }

    public void SwordsInCircle()
    {
        if (!inCircle)
        {
            if (Vector3.Distance(transform.position, prota.transform.position) < size)
            {
                SwordsEnemy.SetActive(true);
                transform.LookAt(new Vector3(prota.transform.position.x, transform.position.y, prota.transform.position.z));
                agent.destination = prota.transform.position;

                if (!inCircle)
                {
                    agent.speed = 15;
                    agent.acceleration = 15;
                }
                
            }
        }
        

        if (Vector3.Distance(transform.position, prota.transform.position) < noMove)
        {
            Debug.Log("No Camina");
            agent.speed = 0;
            inCircle = true;
        }
        else
        {
            inCircle = false;
        }
    }

    public void Attack()
    {
        Instantiate(swordWave, pointShoot.position, pointShoot.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, size);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attack);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, noMove);
    }

    public void Life()
    {
        if (life <= 0)
        {
            Destroy(allContainer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            material.material.color = Color.red;
            life -= bullet.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("LaserProta"))
        {
            material.material.color = Color.red;
            life -= laser.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            material.material.color = Color.red;
            life -= sword.damage;
            Debug.Log("Macheteo");
            StartCoroutine(ChangeColor());
        }

    }

    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        material.material.color = Color.white;
    }
}
