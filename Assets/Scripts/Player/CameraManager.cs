using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;
    [SerializeField] private Camera _camera;
    private InputManager _input;

    [Header("Field of View")]
    [Range(20f, 150f)] [SerializeField] private float _fov;
    [SerializeField] private float _fovTime;
    public float originalFov;

    [Header("Mouse Sensitivity")]
    [SerializeField] [Range(0f, .2f)] private float _sensitivity;
    public bool canMoveCam;
    public float mouseX;
    public float mouseY;

    [Header("Rotations")]
    [SerializeField] private float _camRotation;
    [SerializeField] private float _rotateTime;
    private float _xRotation;
    private float _yRotation;
    private float _zRotation;

    [Header("Position")]
    [SerializeField] private Transform _playerTrans;
    private Transform _trans;

    [Header("Raycast Selection")]
    [SerializeField] private LayerMask _interactLayer;
    [SerializeField] private float _selectionDistance;
    public GameObject selection;
    public RaycastHit raycastHit;
    public bool canSelect;
    private Outline _selectionOutline;
    private bool _hitting;
    private Ray _ray;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private void Start()
    {
        _input = _player.input;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        canMoveCam = true;
        canSelect = true;

        originalFov = _fov;
        _trans = transform;
        _zRotation = 0f;
    }

    private void Update()
    {
        if(canSelect)
            SelectionCheck();
    }

    private void LateUpdate()
    {
        CameraMovement();
    }
    
    private void CameraMovement()
    {
        mouseX = _input.xCameraInput * _sensitivity;
        mouseY = _input.yCameraInput * _sensitivity;

        if(canMoveCam)
            RotateCamera();
    }

    private void RotateCamera()
    {
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -89f, 79f);

        Vector3 rot = _trans.localRotation.eulerAngles;
        _yRotation = rot.y + mouseX;
        
        _trans.localRotation = Quaternion.Euler(_xRotation, _yRotation, _zRotation);
        _playerTrans.localRotation = Quaternion.Euler(0, _yRotation, 0);
    }

    public void ChangeFov(float newFov)
    {
        _fov = Mathf.Lerp(_fov, newFov, _fovTime * Time.deltaTime);
        _camera.fieldOfView = _fov;
    }

    public bool RaycastHitting(float distance)
    {
        Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(Physics.Raycast(ray, out raycastHit, distance))
            return true;
        
        return false;
    }

    public bool SelectionCheck()
    {
        _ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(selection)
            _selectionOutline = selection.GetComponent<Outline>();

        if(Physics.Raycast(_ray, out raycastHit, _selectionDistance, _interactLayer.value))
        {
            GameObject newSelection = raycastHit.collider.gameObject;
            Outline newSelectionOutline = newSelection.GetComponent<Outline>();

            if(selection == null)
                newSelectionOutline.enabled = true;
            else if(selection.GetInstanceID() == newSelection.GetInstanceID())
                newSelectionOutline.enabled = true;
            else
            {
                _selectionOutline.enabled = false;
                newSelectionOutline.enabled = true;
            }

            _hitting = true;
           
            selection = newSelection;
            return true;
        }
        else if(_hitting)
        {
            if(selection)
                _selectionOutline.enabled = false;
                
            _hitting = false;
            selection = null;
            return false;
        }
        
        return false;
    }

    // public void RotateLeft()
    // {
    //     zRotation = Mathf.Lerp(zRotation, -camRotation, rotateTime * Time.deltaTime);
    // }

    // public void RotateRight()
    // {
    //     zRotation = Mathf.Lerp(zRotation, camRotation, rotateTime * Time.deltaTime);
    // }

    // public void EndRotation()
    // {
    //     zRotation = Mathf.Lerp(zRotation, 0, rotateTime * Time.deltaTime);
    // }
}