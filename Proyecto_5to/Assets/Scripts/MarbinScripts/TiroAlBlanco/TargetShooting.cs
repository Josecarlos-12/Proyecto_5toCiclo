using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetShooting : MonoBehaviour
{
    public int life=4;
    public Renderer render, renderTwo;
    public Material hellow, red;

    public enum Feedback
    {
        One,
        Two
        
    }
    public Feedback feedback;

    private void Update()
    {
        switch (feedback)
        {
            case Feedback.One:
                Death();
                break;
            case Feedback.Two:
                DeathTwo();
                break;
        }
        
    }

    public void Death()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DeathTwo()
    {
        if (life <= 2)
        {
            renderTwo.material.color = hellow.color;
            render.material.color = hellow.color;
        }
        if(life <= 1)
        {
            //renderTwo.material.color = red.color;
            //render.material.color = red.color;
            
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
