using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySphere : MonoBehaviour
{
    public float life = 5;
    public Renderer sphere;
    public Material normal, lg;

    private void Update()
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
            life--;
            sphere.material=normal;
            StartCoroutine(NextColor());
        }
        if (other.gameObject.CompareTag("Sword"))
        {
            StartCoroutine(NextColor());
            life -=3;
            sphere.material= normal;
        }
    }


    public IEnumerator NextColor()
    {
        yield return new WaitForSeconds(0.1f);
        sphere.material = lg;
    }
}
