using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCheckpoint : MonoBehaviour
{
    public GameObject checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Destroy(checkpoint);
            Destroy(gameObject);
        }
            
    }
}
