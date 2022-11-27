using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGianLife : MonoBehaviour
{
    public float life=150;
    public Renderer render; 
    public Sword sword;
    public Bullet bullet, laser;
    public GameObject experience;

    [Header("Sonido Robotin")]   
    public int countMusic; 
    public AudioSource deathAudi, damage;
    public Rigidbody rb;
    public bool bDeath;

    void Update()
    {
        if(life <= 0)
        {
            bDeath = true;
            if (countMusic < 3)
            {
                countMusic++;
            }

            if (countMusic == 1)
            {
                render.material.color = Color.red;
                rb.useGravity = true;
                deathAudi.Play();
                Instantiate(experience, transform.position, Quaternion.identity);
                Instantiate(experience, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.identity);
                Destroy(gameObject,1);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!bDeath)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                damage.Play();
                render.material.color = Color.red;
                life -= bullet.damageB;
                StartCoroutine(ChangeColor());
            }
            if (other.gameObject.CompareTag("LaserProta"))
            {
                damage.Play();
                render.material.color = Color.red;
                life -= laser.damageB;
                StartCoroutine(ChangeColor());
            }
            if (other.gameObject.CompareTag("Sword"))
            {
                damage.Play();
                render.material.color = Color.red;
                life -= sword.damage;
                Debug.Log("Macheteo");
                StartCoroutine(ChangeColor());
            }
        }
      
    }

    public IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        render.material.color = Color.white;
    }
}
