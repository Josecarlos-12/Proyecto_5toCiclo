using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlGod : MonoBehaviour
{
    public GameObject enemy;
    public GameObject godDecition;
    public GameObject prota;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DecitionGod()
    {
        godDecition.SetActive(true);
     //   StartCoroutine(OnDecitionBad());
    }

    public IEnumerator OnDecitionGod()
    {
        yield return new WaitForSeconds(5);
        godDecition.SetActive(false);
        prota.SetActive(true);
        Destroy(enemy);
    }
}
