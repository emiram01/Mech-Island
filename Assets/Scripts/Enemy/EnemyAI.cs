using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private GameObject _player;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private LayerMask _groundLayer, _playerLayer;
    [SerializeField] private Material[] _materials;

    private PlayerManager _playerManager; 
    private MeshRenderer _mesh;
    private SkinnedMeshRenderer _skinnedMesh;
    private Outline _outline;
    private bool _changedOutlineV;
    
    [Header("Movement")]
    [SerializeField] private Vector3 _nextPos;
    [SerializeField] private bool _nextPosSet;
    [SerializeField] private float _nextPosRange;
    [SerializeField] private float _sightRange;
    [SerializeField] private bool _inSightRange;
    [SerializeField] private float _stopRange;
    [SerializeField] private bool _inStopRange;
    private Vector3 _lastCheckPos;
    private float _lastCheckTime;
    

    [Header("Attack")]
    [SerializeField] private float _attackTime;
    [SerializeField] private bool _attacked;
    [SerializeField] private float _attackRange;
    [SerializeField] private bool _inAttackRange;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform[] _bulletSpawns;
    [SerializeField] bool _isCrawler;

    [Header("Health")]
    [SerializeField] private float _health;
    
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerManager = _player.GetComponent<PlayerManager>();
        _mesh = this.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        _skinnedMesh = this.transform.GetChild(1).gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        _outline = GetComponentInChildren<Outline>();
    }

    private void Start()
    {   
        if(_mesh)
            _mesh.material = _materials[Random.Range(0, _materials.Length)];
        
        if(_skinnedMesh)
            _skinnedMesh.material = _materials[Random.Range(0, _materials.Length)];
    }

    private void Update()
    {
        CheckRange();

        if(!_changedOutlineV && _playerManager.wallHackActive)
        {
            _outline.OutlineMode = Outline.Mode.OutlineAll;
            _changedOutlineV  = true;
        }
    }  

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            this.enabled = false;
            _agent.ResetPath();
            _agent.isStopped = true;
            if(_skinnedMesh)
                _skinnedMesh.enabled = false;
            else if(_mesh)
                _mesh.enabled = false;

            GetComponent<Explode>().Boom(new Vector3(2f, 2f, 2f), 10, 8, 2);
        }
    }

    private void CheckRange()
    {
        _inSightRange = Physics.CheckSphere(this.transform.position, _sightRange, _playerLayer);
        _inAttackRange = Physics.CheckSphere(this.transform.position, _attackRange, _playerLayer);
        _inStopRange = Physics.CheckSphere(this.transform.position, _stopRange, _playerLayer);

        if(!_inSightRange && !_inAttackRange)
            Idle();
        if(_inSightRange && !_inAttackRange)
            Follow();
        if(_inSightRange && _inAttackRange)
        {
            if(_isCrawler)
                TakeDamage(_health);
            else
                Attack();

        }
            
    }

    private void SearchNextPosition()
    {
        float randomX = Random.Range(-_nextPosRange, _nextPosRange);
        float randomZ = Random.Range(-_nextPosRange, _nextPosRange);

        _nextPos = new Vector3(this.transform.position.x + randomX, this.transform.position.y, this.transform.position.z + randomZ);

        NavMeshHit hit;
        if(NavMesh.SamplePosition(_nextPos, out hit, 25f, NavMesh.AllAreas))
            _nextPosSet = true;
    }
    
    private void Idle()
    {
        if(!_nextPosSet)
            SearchNextPosition();

        if(_nextPosSet)
            _agent.SetDestination(_nextPos);
           
        Vector3 distanceToNextPos = this.transform.position - _nextPos;

        if(distanceToNextPos.magnitude < 1f)
            _nextPosSet = false;      

        if ((Time.time - _lastCheckTime) > 0.5f)
        {
            if((this.transform.position - _lastCheckPos).magnitude < 0.1f)
                SearchNextPosition();

            _lastCheckPos = this.transform.position;
            _lastCheckTime = Time.time;
        }
    }

    private void Follow()
    {
        this.transform.LookAt(_player.transform);
        _agent.SetDestination(_player.transform.position);
    }

    private void Attack()
    {            
        if(!_inStopRange)
            Follow();
        else
        {
            this.transform.LookAt(_player.transform);
            Idle();
        }
            
        if(!_attacked)
        {
            foreach(Transform spawn in _bulletSpawns)
                Instantiate(_bullet, spawn);

            _attacked = true;
            Invoke(nameof(ResetAttack), _attackTime);
        }
    }

    private void ResetAttack()
    {
        _attacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
    }
}
