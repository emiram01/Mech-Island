using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private ActionInput _input;
    private Keyboard _kb;

    private Vector2 _movementInput;
    private Vector2 _cameraInput;

    public float xInput, yInput;
    public float xCameraInput, yCameraInput;
    public bool runInput;
    public bool crouchInput;
    public bool boostInput;
    public bool jumpInput;
    public bool kickInput;
    public bool rightMouseInput;
    public bool leftMouseInput;

    // public bool quick1Input;
    // public bool quick2Input;
    // public bool quick3Input;
    // public bool quick4Input;
    // public bool interactInput;

    public bool testInput;

    private void OnEnable()
    {
        if(_input == null)
        {
            _input = new ActionInput();

           _input.Player.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
           _input.Player.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();

           _input.Player.Run.performed += i => runInput = true;
           _input.Player.Run.canceled += i => runInput = false;

           _input.Player.Crouch.performed += i => crouchInput = true;
           _input.Player.Crouch.canceled += i => crouchInput = false;

           _input.Player.Jump.performed += i => jumpInput = true;

           _input.Player.Slide.performed += i => boostInput = true;

           _input.Player.Kick.performed += i => kickInput = true;

           _input.Player.RightMouse.performed += i => rightMouseInput = true;

           _input.Player.LeftMouse.performed += i => leftMouseInput = true;

        //    _input.Player.Interact.performed += i => interactInput = true;

        //    _input.Player.Quick1.performed += i => quick1Input = true;
        //    _input.Player.Quick2.performed += i => quick2Input = true;    
        //    _input.Player.Quick3.performed += i => quick3Input = true;
        //    _input.Player.Quick4.performed += i => quick4Input = true;

           _input.Player.TEST.performed += i => testInput = true;
        }
       _input.Enable();
    }

    private void OnDisable()
    {
       _input.Disable();
    }

    private void Start()
    {
        _kb = InputSystem.GetDevice<Keyboard>();
    }

    private void Update()
    {
        GetInput();
    }

    private void LateUpdate()
    {
        ResetInput();
    }

    private void GetInput()
    {
        xInput = _movementInput.x;
        yInput = _movementInput.y;

        xCameraInput = _cameraInput.x;
        yCameraInput = _cameraInput.y;
    }

    private void ResetInput()
    {
        jumpInput = false;
        boostInput = false;
        kickInput = false;
        rightMouseInput = false;
        leftMouseInput = false;
        // interactInput = false;
        // quick1Input = false;
        // quick2Input = false;
        // quick3Input = false;
        // quick4Input = false;
        testInput = false;
    }
}
