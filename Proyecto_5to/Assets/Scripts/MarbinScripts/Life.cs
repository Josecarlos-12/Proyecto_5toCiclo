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

 
    private void Start()
    {
        
        //damage.material.color= color;
    }

    public void Update()
    {
       
            LifeDestroy();
            image.fillAmount = life / maxLife;
    }

    public void LifeDestroy()
    {
        // Si la vida en menor a 0 que el protagonista se destruya
        if (life <= 0)
        {
            white.material.color = Color.green;
            player.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
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


    private void OnTriggerEnter(Collider other)
    {
        if (!intan)
        {
            //Si toca al enemigo que le baje vida
            if (other.gameObject.CompareTag("BulletRobotin"))
            {
                life-=50;
            }
            if (other.gameObject.CompareTag("LaserTuto"))
            {
                life-=200;
            }
            if (other.gameObject.CompareTag("Gigant"))
            {
                life -= 50;
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
        if (other.gameObject.name == "PunchLarry")
        {
            move.move = false;
            rb.AddForce(Vector3.right * 5, ForceMode.Impulse);
            //rb.AddForce(Vector3.up, ForceMode.Impulse);               
            life -= 100;
            StartCoroutine("LarryFalse");
        }        
    }

    public IEnumerator LarryFalse()
    {
        yield return new WaitForSeconds(1f);
        move.move = true;
    }

    public IEnumerator IntangibleFalse()
    {
        yield return new WaitForSeconds(3);
        intan = false;
        white.material.color = Color.white;
    }
       
}
