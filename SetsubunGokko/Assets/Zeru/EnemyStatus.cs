using System.Collections;
using UnityEngine;
public class EnemyStatus : MonoBehaviour
{
    [Header("Speed")]
    public float baseSpeed = 2f;
    [Header("Slow on Bean Hit")]
    public float slowMultiplier = 0.5f;   // slower = 50% speed
    public float slowDuration = 2f;
    [Header("Blink")]
    public float blinkInterval = 0.1f;
    SpriteRenderer sr;
    EnemyChase4Dir chase;
    Coroutine slowRoutine;
    Coroutine blinkRoutine;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        chase = GetComponent<EnemyChase4Dir>();
    }
    public void OnBeanHit()
    {
        // Blink
        if (blinkRoutine != null) StopCoroutine(blinkRoutine);
        blinkRoutine = StartCoroutine(Blink());
        // Slow (refreshes duration if hit again)
        if (slowRoutine != null) StopCoroutine(slowRoutine);
        slowRoutine = StartCoroutine(SlowTemporarily());
    }
    IEnumerator SlowTemporarily()
    {
        if (chase != null) chase.speed = baseSpeed * slowMultiplier;
        yield return new WaitForSeconds(slowDuration);
        if (chase != null) chase.speed = baseSpeed;
    }
    IEnumerator Blink()
    {
        // blink a few times (independent of slow duration)
        for (int i = 0; i < 6; i++)
        {
            if (sr != null) sr.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            if (sr != null) sr.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
        }
        if (sr != null) sr.enabled = true;
    }
}