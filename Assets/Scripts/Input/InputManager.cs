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
    public bool jumpInput;
    public bool rightMouseInput;
    public bool leftMouseInput;
    public bool numOne;
    public bool numTwo;

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

            _input.Player.Jump.performed += i => jumpInput = true;

            _input.Player.NumOne.performed += i => numOne = true;
            _input.Player.NumTwo.performed += i => numTwo = true;

            _input.Player.RightMouse.performed += i => rightMouseInput = true;
            _input.Player.RightMouse.canceled += i => rightMouseInput = false;

            _input.Player.LeftMouse.performed += i => leftMouseInput = true;
            _input.Player.LeftMouse.canceled += i => leftMouseInput = false;

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
        rightMouseInput = false;
        // leftMouseInput = false;
        numOne = false;
        numTwo = false;
        testInput = false;
    }
}
