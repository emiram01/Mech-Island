using System.Collections;
using UnityEngine;

public class HomingLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    public void Shoot()
    {
        GameObject rocket = Instantiate(_rocketPrefab, _spawnPos.position, _rocketPrefab.transform.rotation);
        rocket.transform.LookAt(_target.transform);
        StartCoroutine(SpawnRocket(rocket));
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
    }
}
