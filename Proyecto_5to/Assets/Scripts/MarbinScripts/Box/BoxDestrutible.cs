using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestrutible : MonoBehaviour
{
    public int life = 4;
    public Renderer render, renderTwo;
    public Material hellow, red;

    private void Update()
    {
        DeathTwo();
    }

    public void DeathTwo()
    {
        if (life <= 2)
        {
            renderTwo.material = hellow;
            render.material = hellow;
        }
        if (life <= 1)
        {
            renderTwo.material= red;
            render.material = red;

        }
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("LaserProta") || other.gameObject.CompareTag("Sword"))
        {
            life--;
        }
    }
}
