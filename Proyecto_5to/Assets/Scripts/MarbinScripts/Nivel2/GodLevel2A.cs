using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GodLevel2A : MonoBehaviour
{

    public GameObject boss, prota, cameraGod;
    public float[] floaLife;
    [TextArea(4, 4)]
    public string[] sLife;
    public GameObject textGame;
    public TextMeshProUGUI textMesh;
    public Collider col;

    public AudioSource audi;
    public AudioClip final;


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(boss != null)
            {
                prota.SetActive(false);
                cameraGod.SetActive(true);
                StartCoroutine(Dialogue());
                col.enabled = false;
            }
            
        }   
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(floaLife[0]);
        audi.clip = final;
        audi.Play();
        textMesh.text = sLife[0];
        textGame.SetActive(true);
        yield return new WaitForSeconds(floaLife[1]);
        textMesh.text = sLife[1];
        yield return new WaitForSeconds(floaLife[2]);
        textGame.SetActive(false);
        SceneManager.LoadScene("LobbyScene3");
    }
}
