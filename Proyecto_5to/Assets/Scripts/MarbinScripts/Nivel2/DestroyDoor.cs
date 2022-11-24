using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    public GameObject Door;

    public void Destoy()
    {
        Destroy(Door);
    }
}
