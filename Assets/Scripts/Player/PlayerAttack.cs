using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;
    [SerializeField] private CharacterController _controller;
    private InputManager _input;

    [Header("Weapons")]
    [SerializeField] private MiniGun _miniGun;
    [SerializeField] private GameObject[] _miniGunModels;
    [Space]
    [SerializeField] private HomingLauncher _homingLauncher;
    [SerializeField] private GameObject[] _launcherModels;
    private GameObject[] _currentModels;
    private int _lastAttack;

    private void Start()
    {
        _input = _player.input;
        _lastAttack = _player.currentAttack;
        _currentModels = _launcherModels;
    }

    public void CheckAttack()
    {
        if(_input.leftMouseInput)
        {
            switch(_player.currentAttack)
            {
                case 1:
                    _miniGun.Shoot();
                    break;
                case 2:
                    _homingLauncher.Shoot();
                    _input.leftMouseInput = false;  
                    break;
                default:
                    break;
            }
        }

        if(_player.currentAttack != _lastAttack)
        {
            ChangeAttack();
            _lastAttack = _player.currentAttack;
        }
    }

    public void ChangeAttack()
    {
        if(_currentModels != null)
            ChangeModel(_currentModels, false);

        switch(_player.currentAttack)
        {
            case 1:
                ChangeModel(_miniGunModels, true);
                break;
            case 2:
                ChangeModel(_launcherModels, true); 
                break;
            default:
                break;
        }
    }

    private void ChangeModel(GameObject[] models, bool active)
    {
        _currentModels = models;

        foreach(GameObject model in models)
        {
            model.SetActive(active);
        }
    }
}