using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class DashController : MonoBehaviour
{
    public bool canDash;
    public float dashSpeed;
    Rigidbody rb;
    bool isDashing;

    public GameObject dashEffect;

    public Energy energy;

    public Volume volume;
    public Vignette vi;
    public bool bvin;
    public float intensity=0.2f;
    void Start()
    {
        volume.profile.TryGet(out Vignette vignette);
        vi = vignette;
        rb =GetComponent<Rigidbody>();
    }

     void Update()
    {
        if (PlayerPrefs.GetInt("Dash") == 1)
        {
            canDash=true;
        }

        if (bvin)
        {
            if (vi.intensity.value < intensity)
            {
                vi.intensity.value += 0.1f;
            }            
        }
        else
        {
            if (vi.intensity.value > 0)
                vi.intensity.value -= 0.1f;
        }

            if (canDash)
        {
            
            if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && !energy.use)
            {
                
                if (energy.energy > 150)
                {
                    
                    bvin = true;

                    StartCoroutine(Dash());
                    if (Input.GetAxis("Vertical") != 0)
                    {
                        energy.ReductionEnergyDash();
                    }
                    if (Input.GetAxis("Horizontal") != 0)
                    {
                        energy.ReductionEnergyDash();
                    }
                }

            }
        }
        
    }

    private void FixedUpdate()
    {
       // if(isDashing)
        //Dashing();
    }

    private void Dashing()
    {
        
        isDashing=false;

        GameObject effect= Instantiate(dashEffect, Camera.main.transform.position, dashEffect.transform.rotation);
        effect.transform.parent=Camera.main.transform;
        effect.transform.LookAt(transform);
    }

    
    public IEnumerator Dash()
    {
        isDashing = true;
        float timer = 0;

        while (timer < 1)
        {
            
            float vertical = Input.GetAxisRaw("Vertical");
            float horizontal = Input.GetAxisRaw("Horizontal");
            timer += Time.deltaTime;
            rb.AddForce(transform.forward * dashSpeed * vertical, ForceMode.Impulse);
            rb.AddForce(transform.right * dashSpeed * horizontal, ForceMode.Impulse);
            yield return new WaitForEndOfFrame();
        }
        bvin = false;
        yield return null;
        isDashing = false;
    }
}
