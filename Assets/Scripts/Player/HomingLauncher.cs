using System.Collections;
using UnityEngine;

public class HomingLauncher : MonoBehaviour
{
    [SerializeField] private InputManager _input;
    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _speed;

    private void Update()
    {
        
    }

    private void CheckInput()
    {
        if(_input.rightMouseInput)
        {
            GameObject rocket = Instantiate(_rocketPrefab, _spawnPos.position, _rocketPrefab.transform.rotation);
            rocket.transform.LookAt(_target.transform);
            StartCoroutine(Shoot(rocket));
        }
    }

    private IEnumerator Shoot(GameObject rocket)
    {
        while(Vector3.Distance(_target.transform.position, rocket.transform.position) > 0.5f)
        {
            rocket.transform.position += (_target.transform.position - rocket.transform.position).normalized * _speed * Time.deltaTime;
            rocket.transform.LookAt(_target.transform);
            yield return null;
        }
        Destroy(rocket);
    }
}
