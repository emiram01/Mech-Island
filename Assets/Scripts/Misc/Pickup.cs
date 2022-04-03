using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int itemID;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _posSpeed;
    private Vector3 _startingPos;

    void Start()
    {
        _startingPos = this.transform.position;
    }

    void Update()
    {
        Vector3 position = _startingPos;
        position.y = 0.75f * Mathf.Sin(_posSpeed * Time.time) + _startingPos.y;
        this.transform.position = position;
        this.transform.Rotate(_rotation * _rotSpeed * Time.deltaTime);
    }
}
