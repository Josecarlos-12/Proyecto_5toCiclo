using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LifeBossL2 : MonoBehaviour
{
    public float MaxHP = 100;
    public float HP = 100;
    public Renderer render;
    public Sword sword;
    public Bullet bullet, laser;
    public int count, counIn, counIn2, countLife, countAn;
    public int count2, count3, count4;
    public int countT, countT1, countT2;
    public Image image;

    public GameObject[] spheres;
    public bool intan;
    public Transform player;
    public float detecte, punch;
    public RogueBossMeleeV2 melee;
    public GameObject groupSphere, groupSphereLeft;

    public GameObject larrys;
    public DesactiveHabilities habilities;
    public RogueBossFireV2 fire;

    public Material rose, normal;

    public GameObject prota, cam;
    public Animator anim;

    public Transform one, two, three, four;
    public bool death;


    [Header("Vida Final")]
    public Renderer tp;
    public Material liTP, tpNormal;
    public Collider next;
    public GameObject cam2;
    private void Start()
    {
        anim.enabled = false;
    }

    void Update()
    {
        Lockea();
        UpdateLife();
        Death();
        DestroySpheres();
        Punch();
    }
    public void Lockea()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < detecte)
        {
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.transform.position.z));
        }            
    }

    public void Punch()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < punch && !death)
        {
            melee.Active = true;
        }
    }

    public void UpdateLife()
    {
        image.fillAmount = HP / MaxHP;

        if (HP <= 1000)
        {
            if(countAn<3)
            countAn++;

            if (countAn == 1)
            {
                intan = false;
                groupSphereLeft.SetActive(true);
                render.material = rose;
            }            
        }


        if (HP <= 600)
        {
            groupSphere.SetActive(true);

            if(countLife<3)
            countLife++;

            if (countLife == 1)
            {
                intan = false;
                render.material = rose;
            }
            
        }

        if (HP <= 800)
        {
            if (count2 < 3)
                count2++;

            if (count2 == 1)
            {
                Instantiate(larrys,new Vector3(transform.position.x+6, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(larrys, new Vector3(transform.position.x - 6, transform.position.y, transform.position.z), Quaternion.identity);

                Instantiate(larrys, new Vector3(one.transform.position.x, transform.position.y, one.transform.position.z), Quaternion.identity);
                Instantiate(larrys, new Vector3(two.transform.position.x, transform.position.y, two.transform.position.z), Quaternion.identity);

                Instantiate(larrys, new Vector3(three.position.x, transform.position.y, three.position.z), Quaternion.identity);
                Instantiate(larrys, new Vector3(four.position.x, transform.position.y, four.position.z), Quaternion.identity);
            }

        }
        if (HP <= 500)
        {
            if (count3 < 3)
                count3++;

            if (count3 == 1)
            {
                Instantiate(larrys, new Vector3(transform.position.x + 6, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(larrys, new Vector3(transform.position.x - 6, transform.position.y, transform.position.z), Quaternion.identity);

                Instantiate(larrys, new Vector3(one.transform.position.x, transform.position.y, one.transform.position.z), Quaternion.identity);
                Instantiate(larrys, new Vector3(two.transform.position.x, transform.position.y, two.transform.position.z), Quaternion.identity);

                Instantiate(larrys, new Vector3(three.position.x, transform.position.y, three.position.z), Quaternion.identity);
                Instantiate(larrys, new Vector3(four.position.x, transform.position.y, four.position.z), Quaternion.identity);
            }
        }
        if (HP <= 200)
        {
            if (count4 < 3)
                count4++;

            if (count4 == 1)
            {
                Instantiate(larrys, new Vector3(transform.position.x + 6, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(larrys, new Vector3(transform.position.x - 6, transform.position.y, transform.position.z), Quaternion.identity);

                Instantiate(larrys, new Vector3(one.transform.position.x, transform.position.y, one.transform.position.z), Quaternion.identity);
                Instantiate(larrys, new Vector3(two.transform.position.x, transform.position.y, two.transform.position.z), Quaternion.identity);

                Instantiate(larrys, new Vector3(three.position.x, transform.position.y, three.position.z), Quaternion.identity);
                Instantiate(larrys, new Vector3(four.position.x, transform.position.y, four.position.z), Quaternion.identity);
            }
        }


        if (HP <= 300)
        {
            habilities.damageRandon= true;
            fire.active2 = true;
        }

        if (HP <= 900)
        {
            if (countT < 3)
                countT++;

            if (countT == 1)
                Debug.Log("Dialogo1");
        }
        if (HP <= 500)
        {
            if (countT1 < 3)
                countT1++;

            if (countT1 == 1)
                Debug.Log("Dialogo2");
        }
        if(HP <= 100)
        {
            death = true;
            fire.active2 = false;
            fire.Active = false;

            if (countT2 < 3)
                countT2++;

            if (countT2 == 1)
            {
                Debug.Log("Dialogo3");
                Final();
                
                anim.enabled = true;
                FinalTP();
                //anim.SetBool("Deaht", true);
            }
                
        }

    }

    public IEnumerator FinalTP()
    {
        yield return new WaitForSeconds(1);
        tp.material = liTP;
        yield return new WaitForSeconds(1);
        tp.material = tpNormal;
        yield return new WaitForSeconds(1);
        tp.material = liTP;
        yield return new WaitForSeconds(2);
        cam2.SetActive(false);
        prota.SetActive(true);
        next.enabled = true;
    }

    public void DestroySpheres()
    {
        if (spheres[0] ==null && spheres[1] == null && spheres[2] == null)
        {
            if(counIn<3)
            counIn++;

            if (counIn == 1)
            {
                intan = true;
                render.material = normal;
            }
            
        }
        if (spheres[3] == null && spheres[4] == null && spheres[5] == null)
        {
            if (counIn2 < 3)
                counIn2++;

            if (counIn2 == 1)
            {
                render.material = normal;
                intan = true;
            }
                
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (intan)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                render.material.color = Color.red;
                HP -= bullet.damageB;
                StartCoroutine(ChangeColor());
            }
            if (other.gameObject.CompareTag("Sword"))
            {
                render.material.color = Color.red;
                HP -= sword.damage;
                Debug.Log("Macheteo");
                StartCoroutine(ChangeColor());
            }
            if (other.gameObject.CompareTag("LaserProta"))
            {
                render.material.color = Color.red;
                HP -= laser.damageB;
                StartCoroutine(ChangeColor());
            }
            if (other.gameObject.name == "WaveProta")
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detecte);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, punch);
    }


    public void Final()
    {
        prota.SetActive(false);
        cam.SetActive(true);
        StartCoroutine(CamDesactive());
    }

    public IEnumerator CamDesactive()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(FinalTP());
        //prota.SetActive(true);
        cam.SetActive(false);
        cam2.SetActive(true);
    }
}
