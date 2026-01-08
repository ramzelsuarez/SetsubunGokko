using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerBlink blink = collision.GetComponent<PlayerBlink>();
            if (blink != null)
            {
                blink.Blink();
            }
        }
    }
}
