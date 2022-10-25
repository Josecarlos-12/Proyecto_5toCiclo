using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollision : MonoBehaviour
{
    public Collider tree;
    public bool bulletCollision;
    public Renderer treee;
    public Material brown;
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
        if ( other.gameObject.CompareTag("Bullet") )
        {
            treee.material.color = Color.green;
            bulletCollision = true;
            StartCoroutine(FlashColor());
            //tree.enabled = false;
            Debug.Log("AAAA");
        }
    }
    public IEnumerator FlashColor() 
    {
        yield return new WaitForSeconds(1);
        treee.material.color = brown.color;
    }
}
