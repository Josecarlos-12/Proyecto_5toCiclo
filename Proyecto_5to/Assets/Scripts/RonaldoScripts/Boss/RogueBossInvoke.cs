using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBossInvoke : MonoBehaviour
{
    public bool Active;
    public List<Transform> PointSpawn = new List<Transform>();
    public GameObject Prefabs;
    public float CoolDown = 2.25f;
    public int EnemyCount = 3;
    public int count = 0;
    float timer;
    RogueBossState state;
    void Start()
    {
        state = GetComponent<RogueBossState>();
    }
    void Update()
    {
        if (Active)
        {
            timer += Time.deltaTime;
            if(timer > CoolDown && count < EnemyCount)
            {
                Instantiate(Prefabs, PointSpawn[Random.Range(0, PointSpawn.Count)]);
                count++;
                timer = 0;
            }
            else if (count >= EnemyCount)
            {
                count = 0;
                timer = 0;
                state.state = RogueBossState.State.recharge;
                Active = false;
            }
            
        }
    }
}
