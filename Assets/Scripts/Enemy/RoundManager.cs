using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int totalEnemies;
    public GameObject[] enemyTypes;
    public float spawnInterval;
}

public class RoundManager : MonoBehaviour
{
    [SerializeField] private Wave[] _wave;

    [Header("Spawn Points")]
    [SerializeField] private Transform[] _droneSpawnPoints;
    [SerializeField] private Transform[] _tinySpawnPoints;
    [SerializeField] private Transform _bossSpawnPoint;

    private Wave _currentWave;
    private int _currentWaveNum;
    private bool _canSpawn;
    private float _nextSpawnTime;

    private void Start()
    {
        _currentWaveNum = 0;
        _canSpawn = true;
    }

    private void Update()
    {
        _currentWave = _wave[_currentWaveNum];
        SpawnWave();

        GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(currentEnemies.Length == 0 && !_canSpawn)
        {
            _currentWaveNum++;
            _canSpawn = true;
        }
    }

    private void SpawnWave()
    {
        if(_canSpawn && _nextSpawnTime < Time.time)
        {
            int enemyType = Random.Range(0, _currentWave.enemyTypes.Length);
            GameObject enemy = _currentWave.enemyTypes[enemyType];
            Transform spawn;

            switch(enemyType)
            {  
                case 0:
                    spawn = _tinySpawnPoints[Random.Range(0, _tinySpawnPoints.Length)];
                    break;
                case 1:
                    spawn = _droneSpawnPoints[Random.Range(0, _droneSpawnPoints.Length)];
                    break;
                default:
                    spawn = null;
                    print("enemy type oob");
                    break;
            }

            if(spawn && enemy)
            {
                Instantiate(enemy, spawn.position, Quaternion.identity);
                _currentWave.totalEnemies--;
                _nextSpawnTime = Time.time + _currentWave.spawnInterval;
            }

            if(_currentWave.totalEnemies == 0)
                _canSpawn = false;

            // if(_currentWaveNum == 5)
            // {
            //     //spawn boss
            // }
        }

    }
}
