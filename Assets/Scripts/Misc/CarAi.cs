using UnityEngine;

public class CarAI : MonoBehaviour
{
    public bool canMove;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;

    [Header("Health")]
    [SerializeField] private int _health;

    private MeshRenderer _mesh;
    private int _waypointIndex;

    private void Start()
    {
        if(canMove)
        {
            this.transform.position = waypoints[_waypointIndex].transform.position;
            _mesh = this.GetComponentInChildren<MeshRenderer>();
        }

        _mesh = this.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(canMove)
        {
            MoveCar();
            TurnCar();
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 70)
        {
            canMove = false;
            Rigidbody rb = this.GetComponentInChildren<Rigidbody>();
            if(rb)
                rb.isKinematic = false;
        }
            
        if(_health <= 0)
        {
            this.enabled = false;
            if(_mesh)
                _mesh.enabled = false;
            
            GetComponentInChildren<Explode>().Boom(new Vector3(3f, 3f, 3f), 15, 10, 3);
        }
    }

    private void MoveCar()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[_waypointIndex].transform.position, _moveSpeed * Time.deltaTime);
        if(transform.position == waypoints[_waypointIndex].transform.position)
            _waypointIndex++;

        if(_waypointIndex == waypoints.Length)
            _waypointIndex = 0;
    }

    private void TurnCar()
    {
        Quaternion rot = Quaternion.LookRotation(waypoints[_waypointIndex].position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }
}