using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{
    [Header("Amount life")]
    [SerializeField] private int life = 100;


    public void Update()
    {
        LifeDestroy();
    }

    public void LifeDestroy()
    {
        // Si la vida en menor a 0 que el protagonista se destruya
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //Si toca al enemigo que le baje vida
        if (other.gameObject.CompareTag("Bullet"))
        {
            life--;
        }
    }
}
