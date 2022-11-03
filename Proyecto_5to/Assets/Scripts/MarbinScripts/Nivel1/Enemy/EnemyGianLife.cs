using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGianLife : MonoBehaviour
{
    public float life=150;
    public Renderer render; 
    public Sword sword;
    public Bullet bullet;
    public GameObject experience;

    void Update()
    {
        if(life <= 0)
        {
            Instantiate(experience, transform.position, Quaternion.identity);
            Instantiate(experience, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            render.material.color = Color.red;
            life -= bullet.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            render.material.color = Color.red;
            life -= sword.damage;
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
