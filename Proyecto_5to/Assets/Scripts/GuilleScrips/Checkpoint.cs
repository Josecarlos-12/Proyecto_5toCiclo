using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] Vector3 vectorPoints;
    [SerializeField] float dead;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -dead)
        {
            player.transform.position = vectorPoints;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            vectorPoints = player.transform.position;
        }
    }
}
