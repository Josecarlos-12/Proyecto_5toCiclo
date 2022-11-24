using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBossInvokeV2 : MonoBehaviour
{
    public bool Active;
    public List<Transform> PointSpawn = new List<Transform>();
    public GameObject Prefabs;
    public float CoolDown = 2.25f;
    public int EnemyCount = 3;
    public int count = 0;
    float timer;
    RogueBossStateV2 state;
    void Start()
    {
        state = GetComponent<RogueBossStateV2>();
    }
    void Update()
    {
        if (Active)
        {
            timer += Time.deltaTime;
            if (timer > CoolDown && count < EnemyCount)
            {
                Instantiate(Prefabs, PointSpawn[Random.Range(0, PointSpawn.Count)]);
                count++;
                timer = 0;
            }
            else if (count >= EnemyCount)
            {
                count = 0;
                timer = 0;
                state.state = RogueBossStateV2.State.recharge;
                Active = false;
            }

        }
    }
}
