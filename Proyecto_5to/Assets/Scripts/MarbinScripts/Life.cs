using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [Header("Amount life")]
    [SerializeField] private float life = 3;
    public float maxLife = 3;
    public Color color;
    public Color newColor= Color.red;
    public Renderer damage;
    public Intangible intangible;
    public Color randonColor;


    public int recover = 3;
    public GameObject prota;

    public Transform positionInitial;

    public Image image;
    public bool recorProta;

    public Transform initialAll;

    public bool active;
    private void Start()
    {
        damage.material.color= color;
    }

    public void Update()
    {
        if (active)
        {
            LifeDestroy();

            image.fillAmount = life / maxLife;
        }        

    }

    public void LifeDestroy()
    {
        // Si la vida en menor a 0 que el protagonista se destruya
        if (life <= 0)
        {
            //Destroy(gameObject);
            //SceneManager.LoadScene("TestingScene");
            
                intangible.Respawn();
            
            
            life = maxLife;
            recover -= 1;
            //Debug.Log("Respaw: " + recover);
        }
        if(recover == 0)
        {
            //prota.SetActive(false);
            Destroy(prota);
            recover = 3;
            //color = Random.ColorHSV(0f, 0.25f, 0.4f, 1f);
            //damage.material.color = Random.ColorHSV(0f,0.25f,0.4f,1f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            //Si toca al enemigo que le baje vida
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (!intangible.respawn)
                {
                    //Debug.Log("Vida: " + life);
                    life--;
                    damage.material.color = newColor;
                }

                StartCoroutine(White());
            }
            if (other.gameObject.name == "Death")
            {
                prota.transform.position = positionInitial.position;
                intangible.RespawnTwo();
                recover -= 1;
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
        
    }


    public IEnumerator White()
    {
        yield return new WaitForSeconds(2);
        if (!intangible.respawn)
        {
            damage.material.color = color;
        }        
    }
}
