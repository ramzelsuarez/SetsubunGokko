using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCombatStatus : MonoBehaviour
{
    [Header("Hits / Game Over")]
    public int maxHits = 3;
    [Header("Invincibility")]
    public float invincibleDuration = 2f;
    [Header("Speed Boost on Hit")]
    public float boostMultiplier = 1.25f; // "slightly increases"
    public float boostDuration = 3f;
    [Header("Blink Feedback")]
    public float blinkInterval = 0.1f;
    int hitCount = 0;
    bool isInvincible = false;
    SpriteRenderer sr;
    PlayerMove move;
    Coroutine invincibleRoutine;
    Coroutine boostRoutine;
    Coroutine blinkRoutine;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        move = GetComponent<PlayerMove>();
    }
    // Enemy will call this
    public void TakeHit()
    {
        if (isInvincible) return;
        hitCount++;
        // Start invincibility + blink
        if (invincibleRoutine != null) StopCoroutine(invincibleRoutine);
        invincibleRoutine = StartCoroutine(InvincibilityCoroutine());
        if (blinkRoutine != null) StopCoroutine(blinkRoutine);
        blinkRoutine = StartCoroutine(BlinkWhileInvincible());
        // Start / refresh speed boost
        if (boostRoutine != null) StopCoroutine(boostRoutine);
        boostRoutine = StartCoroutine(SpeedBoostCoroutine());
        // Check game over
        if (hitCount >= maxHits)
        {
            GameOver();
        }
    }
    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleDuration);
        isInvincible = false;
        // ensure sprite visible at end
        if (sr != null) sr.enabled = true;
    }
    IEnumerator BlinkWhileInvincible()
    {
        while (isInvincible)
        {
            if (sr != null) sr.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            if (sr != null) sr.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
        }
        if (sr != null) sr.enabled = true;
    }
    IEnumerator SpeedBoostCoroutine()
    {
        if (move != null) move.SetSpeedMultiplier(boostMultiplier);
        yield return new WaitForSeconds(boostDuration);
        if (move != null) move.SetSpeedMultiplier(1f);
    }
    void GameOver()
    {
        // simplest "game over" for now:
        // freeze the game + log. (Later you can show UI or load a scene.)
        Debug.Log("GAME OVER (hit 3 times)");
        Time.timeScale = 0f;
        // Optional: if you already have a GameOver scene, use this instead:
        // Time.timeScale = 1f;
        // SceneManager.LoadScene("GameOver");
    }
}