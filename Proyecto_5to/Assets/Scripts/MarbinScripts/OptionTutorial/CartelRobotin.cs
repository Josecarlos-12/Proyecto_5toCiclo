using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartelRobotin : MonoBehaviour
{
    public Renderer render;
    [Header("Amount life")]
    public float Life = 100;
    public Sword sword;
    public Bullet bullet, laser;
    public GameObject experience;


    void Update()
    {       
        LifeDestroy();
    }

    public void LifeDestroy()
    {
        if (Life <= 0)
        {
            Destroy(gameObject);
            Instantiate(experience, transform.position, Quaternion.identity);
            Instantiate(experience, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            render.material.color = Color.red;
            Life -= bullet.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("LaserProta"))
        {
            render.material.color = Color.red;
            Life -= laser.damageB;
            StartCoroutine(ChangeColor());
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            render.material.color = Color.red;
            Life -= sword.damage;
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
