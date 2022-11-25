using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveHabilities : MonoBehaviour
{
    public Weapon weapon;
    public Sword sword;
    public Jump jump;
    public int random;
    public bool damageRandon;

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

    public IEnumerator Active()
    {
        yield return new WaitForSeconds(10);
        weapon.canShoot = true;
        sword.canAtack = true;
        jump.jumpOne = true;
    }
}
