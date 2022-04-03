using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    private float _power;
    private float _radius;
    private float _upForce;
    private bool _exploded;

    public void Boom(Vector3 size, float power, float radius, float upForce)
    {
        _power = power;
        _radius = radius;
        _upForce = upForce;

        if(!_exploded)
        {
            Invoke(nameof(Explosion), 0f);
            GameObject explosion = Instantiate(_explosionPrefab, this.transform) as GameObject;
            explosion.transform.localScale = size;
            explosion.transform.GetChild(0).localScale = size;
            _exploded = true;
        }
    }

    private void Explosion()
    {
        Vector3 explosionPosition = this.transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(explosionPosition, _radius);

        foreach(var hitCollider in hitColliders)
        {
            Rigidbody rb = hitCollider.GetComponent<Rigidbody>();

            if(rb)
            {
                rb.isKinematic = false;
                rb.AddExplosionForce(_power, explosionPosition, _radius, _upForce, ForceMode.Impulse);
            }

            EnemyAI enemy = hitCollider.transform.GetComponent<EnemyAI>();

            CarAI car = hitCollider.transform.GetComponent<CarAI>();

            Health health = hitCollider.transform.GetComponent<Health>();
            if(!car)
                car = hitCollider.transform.GetComponentInParent<CarAI>();

            if(enemy)
                enemy.TakeDamage(5);

            if(car)
            {
                car.TakeDamage(10);
                car.canMove = false;
            }

            if(health)
                health.TakeDamage(7);

            if(hitCollider.tag == "GasPump")
            {
                hitCollider.GetComponent<Explode>().Boom(new Vector3(4f, 4f, 4f), 20, 8, 5);
                foreach(Transform child in hitCollider.transform)
                    if(child.tag != "Rocket")
                        child.gameObject.SetActive(false);
            }
        }

        Destroy(gameObject, 0.8f);
    }
}
