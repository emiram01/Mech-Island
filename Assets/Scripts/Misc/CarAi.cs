using UnityEngine;

public class CarAi : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;

    private int waypointIndex;

    private void Start()
    {
        this.transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        MoveCar();
        TurnCar();
    }

    private void MoveCar()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        if(transform.position == waypoints[waypointIndex].transform.position)
            waypointIndex++;

        if(waypointIndex == waypoints.Length)
            waypointIndex = 0;
    }

    private void TurnCar()
    {
        Quaternion rot = Quaternion.LookRotation(waypoints[waypointIndex].position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rot, turnSpeed * Time.deltaTime);
    }
}