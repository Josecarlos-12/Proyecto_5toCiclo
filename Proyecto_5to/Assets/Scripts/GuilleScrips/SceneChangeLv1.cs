using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeLv1 : MonoBehaviour
{
    [SerializeField] 
    private GameObject RespawnActive;
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
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level1");
            RespawnActive.GetComponent<RandomRespawn>().respawn();

        }
    }
}
