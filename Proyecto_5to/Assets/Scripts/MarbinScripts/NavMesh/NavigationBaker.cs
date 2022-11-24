using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{
    public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate;
    public int count;

    void Update()
    {        

        for (int i = 0; i < surfaces.Length; i++)
        {
            //surfaces[i].BuildNavMesh();
        }
    }

    public void BuildNavMesh()
    {
        if(count<3)
        count++;

        if (count == 1)
        {
            for (int i = 0; i < surfaces.Length; i++)
            {
                surfaces[i].BuildNavMesh();
            }
        }
        
    }

    public void Count()
    {
        count = 0;
    }
}
