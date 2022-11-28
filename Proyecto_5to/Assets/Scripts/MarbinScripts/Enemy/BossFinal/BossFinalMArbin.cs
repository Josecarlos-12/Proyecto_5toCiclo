using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static ActiveOpenDoor;

public class BossFinalMArbin : MonoBehaviour
{
    [Header("Movimiento")]
    public NavMeshAgent agent;
    public float attack, noMove;

    [Header("Attack")]
    public GameObject prota;
    public float size, stop;
    public GameObject swordWave;
    public Transform pointShoot;
    public Animator anim;
    public bool wave, combo, followCombo, inCircle, animAttack, punch;
    public float time, maxTime, maxTime2;
    public GameObject SwordsEnemy;

    [Header("Life")]
    public float life = 200;
    public float maxLife = 1500;
    public Renderer material;
    public Sword sword;
    public Bullet bullet, laser;
    public GameObject allContainer;

    public GameObject bulleta;


    [Header("Shield")]
    public GameObject shield;
    public bool bShield;
    public int iShield, iShield2, iShield3, iShield4, iShield5, iShield6;
    public Collider cProta;
    public float timeShield;
    public int iWave, iWave2, iWave3, iWave4, iWave5, iWave6;
    public bool bWave, bOnda;
    public int onda, iSword, iSword2;
    public float timeOnda, MaxTimeOnda;

    [Header("Imagenes")]
    public Image image;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeImage();
        Bullet();
        if (!bShield && !bWave)
        {
            Follow();
            Combo();
            AnimTrue();
            // SwordWave();
            
        }
        Life();
        // SwordsInCircle();
        LifeController();
        LifeWave();
        LifeSword();
        Onda();
    }

    public void LifeImage()
    {
        image.fillAmount = life / maxLife;
    }

    public void Onda()
    {
        if (bOnda)
        {
            transform.LookAt(new Vector3(prota.transform.position.x, transform.position.y, prota.transform.position.z));

            timeOnda += Time.deltaTime;

            if(timeOnda >= MaxTimeOnda)
            {
                timeOnda = 0;
                anim.SetBool("Attack", true); anim.SetBool("Combo", false);
            }
           
        }
        else
        {
            anim.SetBool("Attack", false); anim.SetBool("Combo", true);
            bWave = false;
        }
    }

    public void LifeSword()
    {
        if (life <= 600)
        {
            if(iSword<=3)
            iSword++;

            if (iSword == 1)
            {
                SwordsEnemy.SetActive(true);
            }

        }
        if (life <= 300)
        {
            if (iSword2 <= 3)
                iSword2++;

            if (iSword2 == 1)
            {
                SwordsEnemy.SetActive(true);
            }
        }
    }

    public void LifeController()
    {
        if (life <= 1200)
        {
            if (iShield < 3)
            {
                iShield++;
            }

            if (iShield == 1)
            {
                bOnda = true;
                StartCoroutine(ShieldTime());
            }
            
        }
        if (life <= 1000)
        {
            if (iShield2 < 3)
            {
                iShield2++;
            }

            if (iShield2 == 1)
            {
                bOnda = true;
                StartCoroutine(ShieldTime());
            }

        }
        if (life <= 800)
        {
            if (iShield3 < 3)
            {
                iShield3++;
            }

            if (iShield3 == 1)
            {
                bOnda = true;
                StartCoroutine(ShieldTime());
            }

        }
        if (life <= 600)
        {
            if (iShield4 < 3)
            {
                iShield4++;
            }

            if (iShield4 == 1)
            {
                bOnda = true;
                StartCoroutine(ShieldTime());
            }

        }
        if (life <= 400)
        {
            if (iShield5 < 3)
            {
                iShield5++;
            }

            if (iShield5 == 1)
            {
                bOnda = true;
                StartCoroutine(ShieldTime());
            }

        }
        if (life <= 200)
        {
            if (iShield6 < 3)
            {
                iShield6++;
            }

            if (iShield6 == 1)
            {
                bOnda = true;
                StartCoroutine(ShieldTime());
            }

        }
    }

    public void LifeWave()
    {
        if(life <= 900)
        {
            if (iWave < 3)
            {
                iWave++;
            }

            if(iWave == 1)
            {
                bWave = true;
                anim.SetBool("Attack", true); anim.SetBool("Combo", false);
            }
        }
        if (life <= 799)
        {
            if (iWave2 < 3)
            {
                iWave2++;
            }

            if (iWave2 == 1)
            {
                bWave = true;
                anim.SetBool("Attack", true); anim.SetBool("Combo", false);
            }
        }
        if (life <= 599)
        {
            if (iWave3 < 3)
            {
                iWave3++;
            }

            if (iWave3 == 1)
            {
                bWave = true;
                anim.SetBool("Attack", true); anim.SetBool("Combo", false);
            }
        }
        if (life <= 399)
        {
            if (iWave4 < 3)
            {
                iWave4++;
            }

            if (iWave4 == 1)
            {
                bWave = true;
                anim.SetBool("Attack", true); anim.SetBool("Combo", false);
            }

        }
        if (life <= 199)
        {
            if (iWave5 < 3)
            {
                iWave5++;
            }

            if (iWave5 == 1)
            {
                bWave = true;
                anim.SetBool("Attack", true); anim.SetBool("Combo", false);
            }
        }
    }

    public IEnumerator ShieldTime()
    {
        yield return new WaitForSeconds(0);
        bShield = true;
        cProta.enabled = false;
        shield.SetActive(true);
        anim.SetBool("Combo", false); 
    }

    public void Bullet()
    {
        if (Vector3.Distance(transform.position, prota.transform.position) < size)
        {
        }
    }

    public void Follow()
    {
        if (!bWave)
        {
            if (Vector3.Distance(transform.position, prota.transform.position) < size && !punch)
            {
                transform.LookAt(new Vector3(prota.transform.position.x, transform.position.y, prota.transform.position.z));
                agent.destination = prota.transform.position;
                agent.speed = 15;
                agent.acceleration = 30;
            }
            else
            {

            }
            if (Vector3.Distance(transform.position, prota.transform.position) < stop)
            {
                agent.speed = 0;
                agent.acceleration = 0;
                punch = true;
            }
            else
            {
                punch = false;
            }
        }
        
    }

    public void Combo()
    {
        if (combo && !bWave)
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
        }
        

        /*if (Vector3.Distance(transform.position, prota.transform.position) < noMove)
        {
            agent.acceleration = 0;
            agent.speed = 0;
            agent.destination = transform.position;
            combo = true;
        }
        else
        {
            combo = false;
        }*/
    }

    public void AnimFalse()
    {
        animAttack = false;
    }

    public void AnimTrue()
    {
        if (!animAttack && !bWave)
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
        if (Vector3.Distance(transform.position, prota.transform.position) < size)
        {
            transform.LookAt(new Vector3(prota.transform.position.x, transform.position.y, prota.transform.position.z));
            if(onda<3)
            onda++;

            if (onda == 1)
            {
                anim.SetBool("Attack", true); anim.SetBool("Combo", false);
            }

            
        }
        else
        {
            anim.SetBool("Attack", false);
        }       
    }

    public void SwordsInCircle()
    {
            if (Vector3.Distance(transform.position, prota.transform.position) < size)
            {
                SwordsEnemy.SetActive(true);
                transform.LookAt(new Vector3(prota.transform.position.x, transform.position.y, prota.transform.position.z));
                //agent.destination = prota.transform.position;

                if (!inCircle)
                {
                    //agent.speed = 15;
                    //agent.acceleration = 15;
                }
                
            }
        

        /*if (Vector3.Distance(transform.position, prota.transform.position) < noMove)
        {
            Debug.Log("No Camina");
            agent.speed = 0;
            inCircle = true;
        }
        else
        {
            inCircle = false;
        }*/
    }

    public void Attack()
    {
        Instantiate(swordWave, pointShoot.position, pointShoot.rotation);
    }
    public void AttackFalse()
    {
        anim.SetBool("Attack", false);
        bWave = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, size);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attack);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stop);
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
        if (!bShield)
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
        

    }

    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        material.material.color = Color.white;
    }
}
