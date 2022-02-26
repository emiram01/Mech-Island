using UnityEngine;

public class EnemyRockets : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;
    private GameObject _target;
    private bool _collided;

    private void Start()
    {
        this.transform.parent = null;
        _target = GameObject.FindGameObjectWithTag("Player");
        Vector3 dir = (_target.transform.position - transform.position).normalized * _speed;
        _rb.velocity = new Vector3(dir.x, dir.y, dir.z);
        Invoke(nameof(Explode), Random.Range(3.5f, 4.5f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Rocket" && collision.gameObject.tag != "Enemy")
            Explode();

        foreach(ContactPoint contact in collision.contacts)
        {
            if(contact.otherCollider.tag == "Rocket")
                Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider);
                
            if(contact.otherCollider.tag == "GasPump")
                contact.otherCollider.GetComponent<Explode>().Boom(new Vector3(4f, 4f, 4f), 20, 8, 5);

            CarAI car = contact.otherCollider.GetComponent<CarAI>();
            if(!car)
                car = contact.otherCollider.GetComponentInParent<CarAI>();

            if(car)
                car.TakeDamage(25);

            return;
        }
    }

    private void Explode()
    {
        if(!_collided)
        {
            GetComponent<Explode>().Boom(new Vector3(0.3f, 0.3f, 0.3f), 1, 1, 2);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            GetComponentInChildren<MeshRenderer>().enabled = false;
            _collided = true;
        }
    }
}
