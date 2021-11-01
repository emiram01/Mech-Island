using UnityEngine;

public class MiniGun : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;
    [SerializeField] private int _damage;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _range;
    [SerializeField] private Transform _leftGun;
    [SerializeField] private Transform _rightGun;
    [SerializeField] private Transform _leftBulletSpawn;
    [SerializeField] private Transform _rightBulletSpawn;
    [SerializeField] private GameObject _bullets;
    [SerializeField] private GameObject _bulletHolePrefab;
    [SerializeField] private float _bulletHoleTimer;
    private CameraManager _cam;
    private float _nextFire;
    private RaycastHit _hit;
    private bool _shooting;

    private void Start()
    {
        _cam = _player.cam;
    }

    private void FixedUpdate()
    {
        if(_shooting && Physics.Raycast(_cam.transform.position, _cam.transform.forward, out _hit, _range) && _hit.transform.GetComponent<Rigidbody>())
        {
            Rigidbody rb = _hit.transform.GetComponent<Rigidbody>();
            Vector3 dir = _cam.transform.forward;
            rb.AddForce(dir, ForceMode.Impulse);
            rb.isKinematic = false;
            _shooting = false;
        }   
    }

    public void Shoot()
    {
        _shooting = true;
        _leftGun.Rotate(Vector3.forward * 500f * Time.deltaTime);
        _rightGun.Rotate(-Vector3.forward * 500f * Time.deltaTime);

        SpawnBullets();

        while(_nextFire <= Time.time)
        {
            _nextFire = Time.time + _fireRate;

            if(Physics.Raycast(_cam.transform.position, _cam.transform.forward, out _hit, _range))
            {
                if(_hit.transform.tag == "GasPump")
                    _hit.transform.GetComponent<Explode>().Boom(new Vector3(4f, 4f, 4f), 20, 8, 5);

                EnemyAI enemy = _hit.transform.GetComponent<EnemyAI>();

                CarAI car = _hit.transform.GetComponent<CarAI>();
                if(!car)
                    car = _hit.transform.GetComponentInParent<CarAI>();

                if(enemy)
                    enemy.TakeDamage(_damage);

                if(car)
                    car.TakeDamage(_damage);

                GameObject bulletHole = Instantiate(_bulletHolePrefab, _hit.point, Quaternion.LookRotation(-_hit.normal));
                bulletHole.transform.SetParent(_hit.transform);
                Destroy(bulletHole, _bulletHoleTimer);
            }
        }
    }
    
    private void SpawnBullets()
    {
        GameObject l = Instantiate(_bullets, _leftBulletSpawn);
        GameObject r = Instantiate(_bullets, _rightBulletSpawn);

        Destroy(l, 0.5f);
        Destroy(r, 0.5f);
    }
}