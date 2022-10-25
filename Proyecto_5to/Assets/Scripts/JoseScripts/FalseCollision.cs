using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseCollision : MonoBehaviour
{
    public Renderer wrong;
    public Material brown;
    public int a;
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
        a++;
        wrong.material.color = Color.red;
        StartCoroutine(FlashColor());
    }

    public IEnumerator FlashColor( )
    {
        yield return new WaitForSeconds(1);
        wrong.material.color = brown.color;
    }
}
