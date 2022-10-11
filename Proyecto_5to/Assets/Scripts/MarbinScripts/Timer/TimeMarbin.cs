using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class TimeMarbin : MonoBehaviour
{
    public float time;
    public float maxTimer;
    public Text text;
    public RespawnGigant respawn;

    void Update()
    {
        Timer();
    }

    public void Timer()
    {
        time += Time.deltaTime;
        text.text = time.ToString("0");

        if (time >= maxTimer)
        {
            time = 0;
            respawn.prota.position = new Vector3(respawn.next[4].position.x, respawn.next[4].position.y + 3, respawn.next[4].position.z);
        }
    }
}
