using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public InputManager input;
    public CameraManager cam;
    public Sway sway;
    [Space]
    public PlayerMovement movement;
    [Space]
    public Stats health;
    public Stats energy; 

    [Header("Player States")]
    public bool isGrounded;
    public bool isRunning;
    public bool isCrouching;
    public bool isBoosting;
    public bool isGrappling;
    [Space]
    public bool canMove;
    // public bool canUseQuick;
    // public bool canAttack;
    // public bool canKick;
    // public bool changedPower;

    private void Start()
    {
        canMove = true;
        // canUseQuick = true;
        // canAttack = true;
        // canKick = true;
    }

    private void Update()
    {
        PlayerState();
    }

    private void PlayerState()
    {
        // if(isGrounded)
        //     animator.Grounded();
        // else
        //     animator.NotGrounded();

        movement.CheckCollision();
        movement.CheckMovementInput();
    }
}
