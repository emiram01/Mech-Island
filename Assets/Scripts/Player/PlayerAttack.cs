using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;
    [SerializeField] private CharacterController _controller;
    private InputManager _input;

    [Header("Weapons")]
    [SerializeField] private MiniGun _miniGun;
    [SerializeField] private HomingLauncher _homingLauncher;

    private void Start()
    {
        _input = _player.input;
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
    }
}