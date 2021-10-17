using UnityEngine;

public class HomingLauncher : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;
    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private GameObject _HomingRocketPrefab;
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
        if(Physics.Raycast(_player.cam.transform.position, _player.cam.transform.forward, out _hit, _range))
        {
            _target = _hit.transform.gameObject;
            if(_target.layer == 9 || _target.layer == 12)
                _target = null;
        }
        
        if(_spawn1)
        {
            if(_target)
                Instantiate(_HomingRocketPrefab, _spawnPos1.position, _player.cam.transform.rotation).GetComponent<HomingRocket>().target = _target;  
            else
                Instantiate(_rocketPrefab, _spawnPos1.position, _player.cam.transform.rotation);
            
            _spawn1 = false;
        }
        else
        {
            if(_target)
                Instantiate(_HomingRocketPrefab, _spawnPos2.position, _player.cam.transform.rotation).GetComponent<HomingRocket>().target = _target;  
            else
                Instantiate(_rocketPrefab, _spawnPos2.position, _player.cam.transform.rotation);

            _spawn1 = true;
        }
    }
}
