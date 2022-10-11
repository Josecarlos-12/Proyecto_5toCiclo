using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{
    public Animator anim;
    public Transform center;
    public float speed;

    public enum Go
    {
        positive,
        negative
    }
    public Go go;

    public void Start()
    {
        //anim = GetComponent<Animator>();

        switch (go)
        {
            case Go.positive:
                StartCoroutine(Return());
                break;
                case Go.negative:
                StartCoroutine(ReturnTwo());
                break;
        }
        
    }

    private void Update()
    {
        center.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }

    public  IEnumerator Return()
    {
        yield return new WaitForSeconds(5);
        speed = -1*speed; 
        yield return new WaitForSeconds(5);
        speed = 1*speed;
        yield return Return();

    }
    public IEnumerator ReturnTwo()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("onFalse");
        speed = -1 * speed;
        yield return new WaitForSeconds(5);
        speed = -1 * speed;
        Debug.Log("OnTrue");
        yield return ReturnTwo();

    }

}
