using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ShieldLife : MonoBehaviour
{
    public int currentLife = 10;
    public int lifeShield = 10;
    public bool duration=false;

    private void Start()
    {
        duration = false;
    }

    private void Update()
    {
        LessLife();
    }

    public void Off()
    {
        this.gameObject.SetActive(false);
    }

    public void LessLife()
    {
        if(lifeShield <= 0)
        {
            duration = true;
        }
    }

  

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            lifeShield -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
}
