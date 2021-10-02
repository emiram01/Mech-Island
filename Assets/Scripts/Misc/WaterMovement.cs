using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private float speed;

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;

    private void Start()
    {
        posA = start.localPosition;
        posB = end.localPosition;
        nextPos = posB;
    }

    private void Move()
    {
        start.localPosition = Vector3.MoveTowards(start.localPosition, nextPos, speed * Time.deltaTime);
        if(Vector3.Distance(start.localPosition, nextPos) <= 0.1f)
        {
            nextPos = nextPos != posA ? posA : posB;
        }
    }

    private void Update()
    {
        Move();
    }
}
