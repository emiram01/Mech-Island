using UnityEngine;
using UnityEngine.AI;

public class DroneAI : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private LayerMask _groundLayer, _playerLayer;
    
    [Header("Movement")]
    [SerializeField] private Vector3 _nextPos;
    [SerializeField] private bool _nextPosSet;
    [SerializeField] private float _nextPosRange;
    [SerializeField] private float _sightRange;
    [SerializeField] private bool _inSightRange;

    [Header("Attack")]
    [SerializeField] private float _attackTime;
    [SerializeField] private bool _attacked;
    [SerializeField] private float _attackRange;
    [SerializeField] private bool _inAttackRange;

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        CheckRange();
    }  

    private void CheckRange()
    {
        _inSightRange = Physics.CheckSphere(this.transform.position, _sightRange, _playerLayer);
        _inAttackRange = Physics.CheckSphere(this.transform.position, _attackRange, _playerLayer);

        if(!_inSightRange && !_inAttackRange)
            Idle();
        if(_inSightRange && !_inAttackRange)
            Follow();
        if(_inSightRange && _inAttackRange)
            Attack();
    }

    private void SearchNextPosition()
    {
        float randomX = Random.Range(-_nextPosRange, _nextPosRange);
        float randomZ = Random.Range(-_nextPosRange, _nextPosRange);

        _nextPos = new Vector3(this.transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(_nextPos, -transform.up, 2f, _groundLayer))
            _nextPosSet = true;
    }
    
    private void Idle()
    {
        print("i");
        if(!_nextPosSet)
            SearchNextPosition();

        if(_nextPosSet)
            _agent.SetDestination(_nextPos);
           

        Vector3 distanceToNextPos = this.transform.position - _nextPos;

        if(distanceToNextPos.magnitude < 1f)
            _nextPosSet = false;
    }

    private void Follow()
    {
        print("f");
        _agent.SetDestination(_player.transform.position);
    }

    private void Attack()
    {
        print("a");
        _agent.SetDestination(this.transform.position);
        transform.LookAt(_player.transform);

        if(!_attacked)
        {
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
