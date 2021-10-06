using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private float _power;
    [SerializeField] private float _radius;
    [SerializeField] private float _upForce;

    public void Boom()
    {
        Invoke(nameof(Explosion), 0.25f);
        Instantiate(_explosionPrefab, this.transform);
    }

    private void Explosion()
    {
        
        Vector3 explosionPosition = this.transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(explosionPosition, _radius);

        foreach(var hitCollider in hitColliders)
        {
            Rigidbody rb = hitCollider.GetComponent<Rigidbody>();

            if(rb)
                rb.AddExplosionForce(_power, explosionPosition, _radius, _upForce, ForceMode.Impulse);

            EnemyAI enemy = hitCollider.transform.GetComponent<EnemyAI>();

            if(enemy)
                enemy.TakeDamage(5);
        }

        Destroy(gameObject);
    }
}
