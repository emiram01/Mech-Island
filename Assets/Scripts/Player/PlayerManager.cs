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
    public Health health;

    [Header("Player States")]
    public bool isGrounded;
    public bool isRunning;
    public bool isCrouching;
    public bool isBoosting;
    public bool isGrappling;
    [Space]
    public bool canMove;
    public bool boostActive;
    public bool wallHackActive;
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

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Pickup>())
        {
            int item = collider.GetComponent<Pickup>().itemID;

            switch(item)
            {
                case 1:
                    currentAttack = 2;
                    attack.canChange = true;
                    break;
                case 2:
                    movement.jumpAmount = 3;
                    break;
                case 3:
                    health.curr += 10;
                    break;
                case 4:
                    wallHackActive = true;
                    break;
                default:
                    break;
            }

            Destroy(collider.gameObject);
        }
    }
}
