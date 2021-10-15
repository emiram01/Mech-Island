using System.Collections;
using UnityEngine;

public class HomingLauncher : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;
    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private Transform _spawnPos1;
    [SerializeField] private Transform _spawnPos2;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _range;
    private GameObject _target;
    private bool _spawn1;
    private RaycastHit _hit;

    public void Shoot()
    {
        GameObject rocket;

        if(_spawn1)
        {
            rocket = Instantiate(_rocketPrefab, _spawnPos1.position, _rocketPrefab.transform.rotation);
            _spawn1 = false;
        }
        else
        {
            rocket = Instantiate(_rocketPrefab, _spawnPos2.position, _rocketPrefab.transform.rotation);
            _spawn1 = true;
        }

        if(Physics.Raycast(_player.cam.transform.position, _player.cam.transform.forward, out _hit, _range))
            _target = _hit.transform.gameObject;

        if(_target)
        {
            rocket.transform.LookAt(_target.transform);
            StartCoroutine(SpawnRocket(rocket));
        }    
    }

    private IEnumerator SpawnRocket(GameObject rocket)
    {
        while(Vector3.Distance(_target.transform.position, rocket.transform.position) > 0.5f)
        {
            rocket.transform.position += (_target.transform.position - rocket.transform.position).normalized * _speed * Time.deltaTime;
            rocket.transform.LookAt(_target.transform);
            yield return null;
        }
        Destroy(rocket);
        Instantiate(_explosionPrefab, _target.transform);
    }
}
