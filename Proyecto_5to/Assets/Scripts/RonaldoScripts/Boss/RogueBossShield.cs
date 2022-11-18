using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBossShield : MonoBehaviour
{
    public bool Shield_1;
    public bool Shield_2;
    public bool DefenseActive = true;
    public GameObject ShieldPrefab;

    public List<Transform> Shield_List = new List<Transform>();
    public int Shields_Actives;

    void Update()
    {
        if (!Shield_1)
        {
            InstantShield();
            Shield_1 = true;
        }
        else if (Shield_1)
        {
            InstantShield();
            Shield_2 = true;
        }

        if(Shields_Actives == Shield_List.Count)
        {
            DefenseActive = false;
        }
    }
    void InstantShield()
    {
        DefenseActive = true;
        for (int i = 0; i < Shield_List.Count; i++)
        {
            Instantiate(ShieldPrefab,Shield_List[i]);
        }
    }

}
