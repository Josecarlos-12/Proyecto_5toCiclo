using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diana : MonoBehaviour
{
    public float vidamaxima = 5;
    public float vida;
    public Image barra;

    void Start()
    {
        vida = vidamaxima;
    }
    void Update()
    {
        barra.fillAmount = vida/vidamaxima;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Gigant") || other.gameObject.CompareTag("BulletSlow"))
        {
            if (vida > 0)
            {
                vida -= 1;
            }
            if(vida == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
