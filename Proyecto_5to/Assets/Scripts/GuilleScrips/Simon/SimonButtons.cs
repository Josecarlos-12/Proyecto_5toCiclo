using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class SimonButtons : MonoBehaviour
{
    [SerializeField] Color defaultColor;
    [SerializeField] Color highlightColor;
    [SerializeField] float resetDelay = 25f;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        ResetButton();
    }

    void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            PressButton();
        }
    }


    public void PressButton()
    {
        sound.Play();
        GetComponent<MeshRenderer>().material.color = highlightColor;
        Invoke("ResetButton", resetDelay);
    }

    void ResetButton()
    {
        GetComponent<MeshRenderer>().material.color = defaultColor;
    }
}
