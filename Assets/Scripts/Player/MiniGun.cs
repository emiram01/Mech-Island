using UnityEngine;

public class MiniGun : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;
    [SerializeField] private int _damage;
    [SerializeField] private float _range;
    [SerializeField] private Transform _leftGun;
    [SerializeField] private Transform _rightGun;
    [SerializeField] private Transform _leftBulletSpawn;
    [SerializeField] private Transform _rightBulletSpawn;
    [SerializeField] private GameObject _bullets;
    private CameraManager _cam;

    private void Start()
    {
        _cam = _player.cam;
    }

    public void Shoot()
    {
        _leftGun.Rotate(Vector3.forward * 500f * Time.deltaTime);
        _rightGun.Rotate(-Vector3.forward * 500f * Time.deltaTime);

        SpawnBullets();

        RaycastHit hit;
        if(Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, _range))
        {
            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();

            if(enemy)
                enemy.TakeDamage(_damage);
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