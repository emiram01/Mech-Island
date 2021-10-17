using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _power;
    [SerializeField] private float _radius;
    [SerializeField] private int _lifeTime;
    private RaycastHit _hit;
    private float _timer;
    private bool _collided;

    private void Update()
    {
        if(!_collided)
            this.transform.position += transform.forward * _speed * Time.deltaTime;

        if(_timer <= _lifeTime)
            _timer += Time.deltaTime;
        else
            Explode();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();

        foreach(ContactPoint contact in collision.contacts)
        {
            if(contact.otherCollider.tag == "Rocket")
                Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider);
                
            if(contact.otherCollider.tag == "GasPump")
                contact.otherCollider.GetComponent<Explode>().Boom(new Vector3(4f, 4f, 4f), 20, 8, 5);

            EnemyAI enemy = contact.otherCollider.GetComponent<EnemyAI>();

            CarAI car = contact.otherCollider.GetComponent<CarAI>();
            if(!car)
                car = contact.otherCollider.GetComponentInParent<CarAI>();

            if(enemy)
                enemy.TakeDamage(20);

            if(car)
                car.TakeDamage(25);

            

            return;
        }
    }

    private void Explode()
    {
        if(!_collided)
        {
            GetComponent<Explode>().Boom(new Vector3(1f, 1f, 1f), _power, _radius, 2);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            GetComponentInChildren<MeshRenderer>().enabled = false;
            _collided = true;
        }
    }
}
