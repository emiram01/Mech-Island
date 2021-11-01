using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public InputManager input;
    public CameraManager cam;
    public Sway sway;
    [Space]
    public PlayerMovement movement;
    public PlayerAttack attack;
    public GameObject explosionPrefab;
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
    public bool boostActive;
    public bool grappleActive;
    public int currentAttack;

    private void Start()
    {
        canMove = true;
    }

    private void Update()
    {
        PlayerState();
    }

    private void PlayerState()
    {
        movement.CheckCollision();
        movement.CheckMovementInput();
        attack.CheckAttack();
    }
}
