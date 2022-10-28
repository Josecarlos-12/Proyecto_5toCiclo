using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSimon : MonoBehaviour
{
    [SerializeField] SimonButtons[] button;
    [Header("Color Order")]
    [SerializeField] List<int> colorOrder;
    [SerializeField] float pickDelay = 4f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PlayGame");
    }

    IEnumerator PlayGame()
    {
        for (int cnt = 0; cnt < 5; cnt++)
        {
            yield return new WaitForSeconds(pickDelay);
            

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
