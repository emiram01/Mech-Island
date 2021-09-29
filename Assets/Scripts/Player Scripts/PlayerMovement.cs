using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;
    [SerializeField] private CharacterController _controller;
    private InputManager _input;
    private CameraManager _cam;
    // private PlayerAnimator _animator;

    [Header("Player Settings")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance;
    [SerializeField] private float _gravity;

    [Header("Movement")]
    public float speedStat;
    [SerializeField] private int _walkSpeed;
    [SerializeField] private float _momentumDrag;
    private float _moveSpeed;
    private float _elapsedTime;

    [Header("Run")]
    [SerializeField] private float _runSpeed;

    [Header("Slide")]
    [SerializeField] private float _slideForce;
    [SerializeField] private float _slideLength;
    [SerializeField] private float _crouchHeight;
    private float _normalHeight;
    private Transform _normalGroundCheck;
    private Vector3 _slideDirection;
    private float _slideTimer;
    
    [Header("Jump")]
    public int jumpAmount;
    public float jumpHeightStat;
    [SerializeField] private float _jumpHeightBase;
    [SerializeField] private float _jumpCooldown;
    private float _jumpHeight;
    private int _jumpCount;
    private bool _jumping;

    [Header("Headbob")]
    [SerializeField] private float headbobSpeed;
    [SerializeField] private float headbobAmount;
    private float defaultYPos;
    private float bobTimer;
    private bool canHeadbob;

    // [Header("Wall Run")]
    // [SerializeField] private float _wallDistance;
    // [SerializeField] private float _minJumpHeight;
    // [SerializeField] private float _wallGravity;
    // [SerializeField] private float _wallSpeed;
    // [SerializeField] private float _wallForce;
    // [SerializeField] private float _wallJumpForce;
    // private RaycastHit _leftWallHit;
    // private RaycastHit _rightWallHit;
    // private bool _wallLeft;
    // private bool _wallRight;

    //Input and Vectors
    private Vector3 _velocity;
    private Vector3 _initialVelocity;
    private Vector3 _currentMomentum;
    private float h, v;

    private void Start()
    {
        _input = _player.input;
        _cam = _player.cam;
        // _animator = _player.animator;

        _moveSpeed = _walkSpeed + speedStat;
        _normalHeight = _controller.height;
        _normalGroundCheck = _groundCheck;

        _jumpHeight = _jumpHeightBase;

        _initialVelocity = _velocity;

        defaultYPos = this.transform.localPosition.y;

        canHeadbob = true;
    }
 
    public void CheckCollision()
    {
        if(!_jumping)
            _player.isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundLayer);
        
        if(_player.isGrounded && _velocity.y < 0)
            _velocity.y = -2f;
    }

    #region General Movement
    public void CheckMovementInput()
    {
        h = _input.xInput;
        v = _input.yInput;

        if(_player.canMove)
        {
            Move();
            // CheckDirection();
            CheckJump();
            CheckRun();
            CheckSlide();
            
            if(canHeadbob)
                Headbob();
        }
        else
        {
            EndRun();
            EndSlide();
        }
    }

    public void Grapple(Vector3 dir, float speed, float multiplier)
    {
        _controller.Move(dir * speed * multiplier * Time.deltaTime);
    }

    public void ResetGravity()
    {
        _velocity.y = 0f;
    }

    private void Move()
    {
        Vector3 move = transform.right * h + transform.forward * v; 

        if(!_player.isGrappling)
        {
            _controller.Move(move * _moveSpeed * Time.deltaTime);
            
            _velocity.y += _gravity * Time.deltaTime;
            
            _velocity += _currentMomentum;

            _controller.Move(_velocity * Time.deltaTime);

            if(_currentMomentum.magnitude >= 0f)
            {
                _velocity -= _currentMomentum;
                _currentMomentum -= _currentMomentum * _momentumDrag * Time.deltaTime;
                
                if(_currentMomentum.magnitude < 0.0f)
                {
                    _currentMomentum = Vector3.zero;
                    _cam.ChangeFov(_cam.originalFov);
                }   
            }
        }

        
    }

    private void Headbob()
    {
        if(!_player.isGrounded)
        {
            _cam.transform.position = this.transform.position;
        }
        else if(h != 0 || v != 0)
        {
            bobTimer += Time.deltaTime * (_player.isRunning ? (headbobSpeed + 7.5f) : headbobSpeed);

            _cam.transform.localPosition = new Vector3(
                this.transform.localPosition.x,
                defaultYPos + Mathf.Sin(bobTimer) * (_player.isRunning ? (headbobAmount + 0.6f) : headbobAmount),
                this.transform.localPosition.z);
        }
    }

    // private void CheckDirection()
    // {
    //     // if(v == 1)
    //     // {
    //     //     _animator.WalkingForward();
    //     // }
    //     // else if(v == -1)
    //     // {
    //     //     _animator.WalkingBack();
    //     // }
    //     // else if(h == -1)
    //     // {
    //     //     _animator.WalkingLeft();
    //     // }
    //     // else if(h == 1)
    //     // {
    //     //     _animator.WalkingRight();
    //     // }

    //     // if(h == 0 && v == 0)
    //         // _animator.Idle();
    // }
    #endregion

    #region Jump
    public void AddMomentum(Vector3 dir, float boost)
    {
        _currentMomentum = dir * boost;
        _cam.ChangeFov(_cam.originalFov + boost);
    }
    
    public void BoostUp()
    {
        _velocity.y = Mathf.Sqrt((_jumpHeight + jumpHeightStat) * -2f * _gravity);
    }

    private void CheckJump()
    {
        if(_input.jumpInput && _jumpCount < jumpAmount)
        {
            _jumping = true;
            _player.isGrounded = false;
            Invoke(nameof(ResetGroundCheck), _jumpCooldown);
            BoostUp();
            _jumpCount++;

            if(_jumpCount > 1)
                AddMomentum(transform.right * h + transform.forward * v, 1.25f);
        }

        if(_jumpCount > 0 && _player.isGrounded)
            ResetJump();

        if(_jumpCount >= 1)
            _jumpHeight = _jumpHeightBase + 0.5f;

        // _animator.SetJumpCount(_jumpCount);
    }

    private void ResetGroundCheck() => _jumping = false;

    private void ResetJump()
    {
        _jumpCount = 0;
        _jumpHeight = _jumpHeightBase;
    }
    #endregion

    #region Run
    private void CheckRun()
    {
        if(_input.runInput)
        {
            if(v != 0 && !_player.isSliding && !_player.isGrappling)
                StartRun();
                
            if(v == 0)
                EndRun();
        }
        else
            EndRun();
    }

    private void StartRun()
    {
            _player.isRunning = true;
            _moveSpeed = _runSpeed + speedStat;
            // _animator.Running();
            _cam.ChangeFov(_cam.originalFov + 10f);
    }

    public void EndRun()
    {
        _input.runInput = false;
        _player.isRunning = false;
        _moveSpeed = _walkSpeed + speedStat;
        // _animator.NotRunning();

        if(!_player.isSliding && !_player.isGrappling)
            _cam.ChangeFov(_cam.originalFov);
    }
    #endregion



    #region Slide
    private void CheckSlide()
    {
        if(_input.slideInput && !_player.isSliding && _player.isRunning)
            StartSlide();
        else if(_slideTimer >= _slideLength)
            EndSlide();
            
        if(_player.isSliding)
            _slideTimer += Time.deltaTime;
    }
    private void StartSlide() 
    {
        _input.runInput = false;
        _controller.height = _crouchHeight;
        // _animator.Sliding();
        _cam.ChangeFov(_cam.originalFov + 15f); 
        
        _moveSpeed = _runSpeed + speedStat;
        _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        Invoke(nameof(SlideForce), 0.15f);
    }
    private void SlideForce()
    {
        _player.isSliding = true;
        _slideDirection = transform.forward;
        _velocity = _slideDirection * _slideForce;
    }

    private void EndSlide()
    {
        if(!_player.isGrappling)
            _cam.ChangeFov(_cam.originalFov);
        Invoke(nameof(ResetSlide), 0.25f);
    }
    private void ResetSlide()
    {
        _player.isSliding = false;
        _moveSpeed = _walkSpeed + speedStat;
        _controller.height = _normalHeight;
        _velocity = _initialVelocity;
        // _animator.NotSliding();
        _slideTimer = 0;
    }
    #endregion

    // private bool CanWallRun()
    // {
    //     return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight);
    // }

    // private void CheckWall()
    // {
    //     wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallDistance);
    //     wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallDistance);
    // }
}