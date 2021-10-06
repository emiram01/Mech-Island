﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;
    [SerializeField] private CharacterController _controller;
    private InputManager _input;
    private CameraManager _cam;

    [Header("Player Settings")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _hurtLayer;
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

    [Header("Boost")]
    [SerializeField] private float _boostForce;
    [SerializeField] private float _boostLength;
    private Vector3 _boostDirection;
    private float _boostTimer;
    
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

        _moveSpeed = _walkSpeed + speedStat;

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

        if(Physics.CheckSphere(_groundCheck.position, _groundDistance, _hurtLayer))
        {
            Collider[] hitColliders = Physics.OverlapSphere(_groundCheck.position, _groundDistance);

            foreach (var hitCollider in hitColliders)
            {
                Instantiate(_player.explosionPrefab, _groundCheck.transform);
                Destroy(hitCollider.gameObject);
            }
        }
    }

    #region General Movement
    public void CheckMovementInput()
    {
        h = _input.xInput;
        v = _input.yInput;

        if(_player.canMove)
        {
            Move();
            CheckJump();
            CheckRun();
            CheckBoost();
            
            if(canHeadbob)
                Headbob();
        }
        else
        {
            EndRun();
            EndBoost();
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
        if((h != 0 || v != 0) && _player.isGrounded && !_player.isBoosting)
        {
            bobTimer += Time.deltaTime * (_player.isRunning ? (headbobSpeed + 7.5f) : headbobSpeed);

            _cam.transform.localPosition = new Vector3(
                this.transform.localPosition.x,
                this.transform.position.y + Mathf.Sin(bobTimer) * (_player.isRunning ? (headbobAmount + 0.6f) : headbobAmount),
                this.transform.localPosition.z);
        } 
        else 
            _cam.transform.position = this.transform.position;
    }
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
                AddMomentum(transform.right * h + transform.forward * v, 25f);
        }

        if(_jumpCount > 0 && _player.isGrounded)
            ResetJump();

        if(_jumpCount >= 1)
            _jumpHeight = _jumpHeightBase + 0.5f;
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
            if(v != 0 && !_player.isBoosting && !_player.isGrappling)
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
            _cam.ChangeFov(_cam.originalFov + 10f);
    }

    public void EndRun()
    {
        _input.runInput = false;
        _player.isRunning = false;
        _moveSpeed = _walkSpeed + speedStat;

        if(!_player.isBoosting && !_player.isGrappling)
            _cam.ChangeFov(_cam.originalFov);
    }
    #endregion



    #region Boost
    private void CheckBoost()
    {
        if(_input.boostInput && !_player.isBoosting && _player.isRunning)
            StartBoost();
        else if(_boostTimer >= _boostLength)
            EndBoost();
            
        if(_player.isBoosting)
            _boostTimer += Time.deltaTime;
    }

    private void StartBoost() 
    {
        _player.isBoosting = true;
        _cam.ChangeFov(_cam.originalFov + 15f); 
        AddMomentum(transform.right * h + transform.forward * v, _boostForce);
    }

    private void EndBoost()
    {
        if(!_player.isGrappling)
            _cam.ChangeFov(_cam.originalFov);
        Invoke(nameof(ResetBoost), 0.25f);
    }
    private void ResetBoost()
    {
        _player.isBoosting = false;
        _moveSpeed = _walkSpeed + speedStat;
        _velocity = _initialVelocity;
        _boostTimer = 0;
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