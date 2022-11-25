using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPartOpenDoor : MonoBehaviour
{
    public RespawnGigant res;
    public void Next()
    {
        res.prota.position = new Vector3(res.next[5].position.x, res.next[5].position.y + 3, res.next[5].position.z);
        res.prota.rotation = res.next[5].rotation;
    }
}
