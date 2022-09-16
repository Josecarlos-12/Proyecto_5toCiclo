using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [Header("Amount life")]
    [SerializeField] private int life = 3;
    public Color color= Color.white;
    public Color newColor= Color.red;
    public Renderer damage;

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
        if (other.gameObject.CompareTag("Enemy"))
        {
            life--;
            damage.material.color = newColor;
            StartCoroutine(White());
        }
    }


    public IEnumerator White()
    {
        yield return new WaitForSeconds(2);
        damage.material.color = color;
    }
}
