using System.Collections;
using UnityEngine;

public class DashController : MonoBehaviour
{
    public float dashSpeed;
    Rigidbody rb;
    bool isDashing;

    public GameObject dashEffect;

    public Energy energy;
    public InteractionHabilities interactions;

    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing &&  !energy.use && interactions.dash)
        {
            
            if (energy.energy > 15)
            {
                energy.ReductionEnergyDash();
                StartCoroutine(Dash());
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
        yield return null;
        isDashing = false;
    }
}
