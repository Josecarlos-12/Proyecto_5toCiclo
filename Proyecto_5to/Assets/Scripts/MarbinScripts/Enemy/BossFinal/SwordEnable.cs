using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnable : MonoBehaviour
{
    public SwordLife[] SwordsD;
    public GameObject[] gSwords;

    public SwordLife one, two, three, four, five, six, seven, eight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!one.bSword && !two.bSword && !three.bSword && !four.bSword && !five.bSword && !six.bSword && !seven.bSword && !eight.bSword)
        {
            StartCoroutine(SwordActive());
        }
    }

    public IEnumerator SwordActive()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < SwordsD.Length; i++)
        {
            SwordsD[i].bSword = true;
            gSwords[i].SetActive(true);
        }
    }
}
