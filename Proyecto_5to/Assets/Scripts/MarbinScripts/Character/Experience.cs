using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    public Image imageExperience;
    public GameObject ObjecExperience;
    public float experience;
    public float maxExperience;

    // Start is called before the first frame update
    void Start()
    {
        ObjecExperience.SetActive(false);
        imageExperience.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        imageExperience.fillAmount = experience / maxExperience;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Experience"))
        {
            if (experience <= maxExperience)
            {
                ObjecExperience.SetActive(true);
                imageExperience.enabled = true;
                experience += 50;
                Destroy(other.gameObject);
                StartCoroutine(Experi());
            }
        }
    }

    public IEnumerator Experi()
    {
        yield return new WaitForSeconds(3);
        imageExperience.enabled = false;
        ObjecExperience.SetActive(false);
    }
}
