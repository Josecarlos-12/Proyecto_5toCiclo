using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceFollow : MonoBehaviour
{
    public GameObject prota;
    public float size;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        prota= GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, prota.transform.position) < size)
        {
            transform.position = Vector3.MoveTowards(transform.position, prota.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
