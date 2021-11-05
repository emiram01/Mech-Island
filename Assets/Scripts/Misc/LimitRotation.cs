using UnityEngine;

public class LimitRotation : MonoBehaviour
{
    [SerializeField] private bool _limitX;
    [SerializeField] private bool _limitY;
    [SerializeField] private bool _limitZ;
    private Vector3 _initialRot;

    private void Start()
    {
        _initialRot = transform.eulerAngles;
    }

    private void LateUpdate()
    {
        if(!_limitX)
            _initialRot.x = this.transform.eulerAngles.x;

        if(!_limitY)
            _initialRot.y = this.transform.eulerAngles.y;

        if(!_limitZ)
            _initialRot.z = this.transform.eulerAngles.z;

        this.transform.eulerAngles = _initialRot;
    }
}
