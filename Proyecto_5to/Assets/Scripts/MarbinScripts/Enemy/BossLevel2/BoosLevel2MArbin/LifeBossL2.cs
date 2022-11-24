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
    public int count;
    public Image image;

    public GameObject[] spheres;
    public bool intan;
    public RogueBossFireV2 fire;
    public Transform player;
    public float detecte;

    private void Start()
    {
        fire.Active = true;
    }

    void Update()
    {
        Lockea();
        UpdateLife();
        Death();
        DestroySpheres();
    }
    public void Lockea()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < detecte)
        {
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.transform.position.z));
        }            
    }

    public void Fire()
    {
        
    }

    public void UpdateLife()
    {
        image.fillAmount = HP / MaxHP;
    }

    public void DestroySpheres()
    {
        if (spheres[0] ==null && spheres[1] == null && spheres[2] == null)
        {
            
            intan = true;
        }
        if (spheres[3] == null && spheres[4] == null && spheres[5] == null)
        {
            intan = true;
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
    }
}
