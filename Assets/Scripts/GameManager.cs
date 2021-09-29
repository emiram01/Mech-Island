using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _spawn;
    [SerializeField] private InputManager _input;

    private void Awake()
    {
        _input = GetComponent<InputManager>();
    }

    private void Start()
    {
        Begin();
    }

    private void Update()
    {
        if(_input.testInput)
            Restart();
    }

    private void Begin()
    {
        _player.transform.position = _spawn;
    }

    private void Restart()
    {
        StopAllCoroutines();
        Begin();
    }
}
