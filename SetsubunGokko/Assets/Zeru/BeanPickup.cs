using UnityEngine;
public class BeanPickup : MonoBehaviour
{
    public int amount = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerBeanShooter shooter = other.GetComponent<PlayerBeanShooter>();
        if (shooter == null) return;
        // If player already has max beans, we still remove the pickup
        shooter.TryAddBeans(amount);
        Destroy(gameObject);
    }
}
