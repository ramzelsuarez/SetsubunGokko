using UnityEngine;
public class BeanProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    Vector2 dir = Vector2.right;
    public void SetDirection(Vector2 direction)
    {
        dir = direction.normalized;
    }
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.position += (Vector3)(dir * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var status = other.GetComponent<EnemyStatus>();
            if (status != null) status.OnBeanHit();
            Destroy(gameObject);
        }
    }
}