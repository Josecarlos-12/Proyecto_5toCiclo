using UnityEngine;

public class DashController : MonoBehaviour
{
    public bool isDashing;

    private int dashAttempts;
    private float dashStarTime;

    MoveRGB playerController;
    CharacterController characterController;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController.GetComponent<MoveRGB>();
        characterController.GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleDash();
    }
    void HandleDash()
    {
        bool isTryingToDash=Input.GetKeyDown(KeyCode.LeftShift);

        if(isTryingToDash&&!isDashing)
        {
            if(dashAttempts<=50)
            {
                OnStartDash();
            }
        }

        if(isDashing)
        {
            if(Time.time-dashStarTime<=0.4f)
            {
                if(playerController.movementVector.Equals(Vector3.zero))
                {
                    characterController.Move(transform.forward*30f*Time.deltaTime);
                }
                else
                {
                    characterController.Move(playerController.movementVector.normalized*30f*Time.deltaTime);
                }
            } else
            {
                OnEndDash();
            }
        }
    }

    void OnStartDash()
    {

    }

    void OnEndDash()
    {

    }

}
