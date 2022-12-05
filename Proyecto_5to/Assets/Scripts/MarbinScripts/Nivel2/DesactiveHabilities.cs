using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DesactiveHabilities : MonoBehaviour
{
    public Weapon weapon;
    public Sword sword;
    public Jump jump;
    public int random;
    public bool damageRandon;

    public TextMeshProUGUI text;
    public GameObject textGame;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            random = Random.Range(0, 3);
            Debug.Log(random);
        }
    }
    //Disparo espada salto normal 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BBB"))
        {
            if (damageRandon)
            {
                textGame.SetActive(true);
                text.text = "Te han desactiva una habilidad temporalmente";
                StartCoroutine(Text());
                Debug.Log("TocoelAzul");
                random = Random.Range(0, 4);
                Debug.Log(random);

                if (random == 0)
                {
                    weapon.canShoot = false;
                }
                if (random == 1)
                {
                    sword.canAtack = false;
                }
                if (random == 2)
                {
                    jump.jumpOne = false;
                }
                StartCoroutine(Active());
            }
        }
    }

    public IEnumerator Text()
    {
        yield return new WaitForSeconds(3);
        textGame.SetActive(false);
    }

    public IEnumerator Active()
    {
        yield return new WaitForSeconds(10);
        weapon.canShoot = true;
        sword.canAtack = true;
        jump.jumpOne = true;
    }
}
