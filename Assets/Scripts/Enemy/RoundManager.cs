using UnityEngine;
[System.Serializable]

public class Round
{
    public string round;
    public int totalEnemies;
    public GameObject[] enemyTypes;
    public float spawnInterval;
}

public class RoundManager : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] private Round[] _rounds;
    [SerializeField] private RoundCounter _counter;

    [Header("Spawn Points")]
    [SerializeField] private Transform[] _droneSpawnPoints;
    [SerializeField] private Transform[] _tinySpawnPoints;
    [SerializeField] private Transform[] _bossSpawnPoints;

    private Round _currentRound;
    private int _currentRoundNum;
    private bool _canSpawn;
    private bool _canAnimate;
    private float _nextSpawnTime;

    private void Start()
    {
        _currentRoundNum = 0;
        _canSpawn = true;

        _counter.UpdateRoundCounter(_currentRoundNum);
    }

    private void Update()
    {
        _currentRound = _rounds[_currentRoundNum];
        SpawnEnemies();

        GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(currentEnemies.Length == 0 && _canAnimate && _currentRoundNum + 1 != _rounds.Length)
        {
            _animator.SetTrigger("RoundComplete");
            _canAnimate = false;
        }
            

        if(_counter.canStart)
            StartNextRound();
    }

    private void StartNextRound()
    {
        _currentRoundNum++;
        _canSpawn = true;
        _counter.canStart = false;
        _counter.UpdateRoundCounter(_currentRoundNum);
    }

    private void SpawnEnemies()
    {
        if(_canSpawn && _nextSpawnTime < Time.time)
        {
            int enemyType = Random.Range(0, _currentRound.enemyTypes.Length);
            GameObject enemy = _currentRound.enemyTypes[enemyType];
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
                _currentRound.totalEnemies--;
                _nextSpawnTime = Time.time + _currentRound.spawnInterval;
            }

            if(_currentRound.totalEnemies == 0)
            {
                _canSpawn = false;
                _canAnimate = true;
            }

            // if(_currentRoundNum == 5)
            // {
            //     //spawn boss
            // }
        }
    }
}
