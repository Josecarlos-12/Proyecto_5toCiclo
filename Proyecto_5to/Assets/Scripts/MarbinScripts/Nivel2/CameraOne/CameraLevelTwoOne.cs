using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevelTwoOne : MonoBehaviour
{
    public GameObject cam, prota;
    public float time = 1.3f;
    public MoveRGB move;
    public NewJump jump;
    public Weapon weapon;
    public DashController dash;

    // Start is called before the first frame update
    void Start()
    {
        prota.SetActive(false);
        cam.SetActive(true);
        StartCoroutine(CameraFalse());
        move.enabled = false;
        jump.enabled= false;
        weapon.enabled = false;
        dash.enabled = false;
    }

    public IEnumerator CameraFalse()
    {
        yield return new WaitForSeconds(time);
        cam.SetActive(false);
        prota.SetActive(true);
        move.enabled = true;
        jump.enabled = true;
        weapon.enabled = true;
        dash.enabled = true;
    }
}
