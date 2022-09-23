using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [Header("Amount life")]
    [SerializeField] private float life = 3;
    [SerializeField] private float maxLife = 3;
    public Color color= Color.white;
    public Color newColor= Color.red;
    public Renderer damage;
    public Intangible intangible;

    public int recover = 3;
    public GameObject prota;

    public Transform positionInitial;

    public Image image;

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
            //Destroy(gameObject);
            //SceneManager.LoadScene("TestingScene");
            intangible.Respawn();
            life = maxLife;
            recover -= 1;
            //Debug.Log("Respaw: " + recover);
        }
        if(recover <= 0)
        {            
            Destroy(prota);
        }
    }


    private void OnTriggerEnter(Collider other)
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
        if(other.gameObject.name == "Death")
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


    public IEnumerator White()
    {
        yield return new WaitForSeconds(2);
        if (!intangible.respawn)
        {
            damage.material.color = color;
        }        
    }
}
