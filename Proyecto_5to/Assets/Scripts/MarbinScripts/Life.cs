using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Life : MonoBehaviour
{
    [Header("Amount life")]
    public float fReLife=30;
    public float life = 3;
    public float maxLife = 3;
    public Color color;
    public Color newColor= Color.red;
    public Renderer white;
    //public Intangible intangible;
    public Color randonColor;


    public int recover = 3;

    public Transform player;

    public Image image;
    public bool recorProta;

    public Rigidbody rb;
    public MoveRGB move;

    public bool intan;

    [Header("Perdiste")]
    public GameObject over;

    [Header("Regenerar Vida")]
    public bool regeneration;
    public float time, maxTime;
    
 
    private void Start()
    {
        
        //damage.material.color= color;
    }

    public void Update()
    {
        Regeneration();
            LifeDestroy();
            image.fillAmount = life / maxLife;
    }

    public void Regeneration()
    {
        if (regeneration)
        {
            time += Time.deltaTime;
            if (time > maxTime)
            {
                time = 0;
                if (life < maxLife)
                {
                    life += fReLife;
                }
                    
            }
        }        
    }

    public void LifeDestroy()
    {
        // Si la vida en menor a 0 que el protagonista se destruya
        if (life <= 0)
        {
            white.material.color = Color.green;
            player.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            intan = true;
            life = maxLife;
            recover -= 1;
            StartCoroutine(IntangibleFalse());
        }
        if(recover == 0)
        {
            //Destroy(prota);
           
            //recover = 3;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!intan)
        {
            if (other.gameObject.CompareTag("BB2"))
            {
                life -= 1;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!intan)
        {
            //Si toca al enemigo que le baje vida
            if (other.gameObject.CompareTag("BulletRobotin"))
            {
                life-=20;
            }
            if (other.gameObject.CompareTag("LaserTuto"))
            {
                life-=200;
            }
            if (other.gameObject.CompareTag("Gigant"))
            {
                life -= 50;
            }
            if (other.gameObject.CompareTag("WaveSword"))
            {
                life -= 50;
            }
            if (other.gameObject.name == "PunchLarry")
            {
                //move.move = false;
                //Este Funciona
                //rb.AddForce(((Vector2)(transform.position - other.gameObject.transform.position)).normalized * 8, ForceMode.Impulse);

                //rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
                //rb.AddForce(Vector3.up, ForceMode.Impulse);               
                life -= 50;
                //StartCoroutine("LarryFalse");
            }
            if (other.gameObject.CompareTag("SwordBoss"))
            {
                life -= 100;
            }
            if (other.gameObject.CompareTag("EnemyWeapon"))
            {
                life -= 100;
            }
        }
        if (other.gameObject.CompareTag("MaxLife"))
        {
            life = maxLife;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Recover"))
        {
            recover += 1;
            Destroy(other.gameObject);
        }
        
    }

    public IEnumerator LarryFalse()
    {
        yield return new WaitForSeconds(0.3f);
        move.move = true;
    }

    public IEnumerator IntangibleFalse()
    {
        yield return new WaitForSeconds(3);
        intan = false;
        white.material.color = Color.white;
    }
       
}
