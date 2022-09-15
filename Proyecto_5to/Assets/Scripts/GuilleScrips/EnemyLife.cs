using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    public int Life;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

     private void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Life -= 10;
            if (Life <= 0)
            {
                Destroy(gameObject);
            }
        }
     }

    
}
