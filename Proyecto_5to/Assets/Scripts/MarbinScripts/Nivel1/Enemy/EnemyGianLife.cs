using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGianLife : MonoBehaviour
{
    public int life=150;
    public Renderer render;

    void Update()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            render.material.color = Color.red;
            life -= 20;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            render.material.color = Color.red;
            life -= 50;
            Debug.Log("Macheteo");
            StartCoroutine(ChangeColor());
        }
    }

    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        render.material.color = Color.white;
    }
}
