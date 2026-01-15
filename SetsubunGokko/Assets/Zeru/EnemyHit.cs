using UnityEngine;
public class EnemyHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        PlayerCombatStatus pcs = collision.GetComponent<PlayerCombatStatus>();
        if (pcs != null)
        {
            pcs.TakeHit();
        }
    }
}