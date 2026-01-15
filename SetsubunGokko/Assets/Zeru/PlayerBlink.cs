using System.Collections;
using Unity.Hierarchy;
using UnityEngine;

public class PlayerBlink : MonoBehaviour
{
    public float blinkDuration = 0.1f;
    public int blinkCount = 5;

    SpriteRenderer sr;
    bool isBlinking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Blink()
    {
        if (!isBlinking)
            StartCoroutine(BlinkCoroutine());
    }

    IEnumerator BlinkCoroutine()
    {
        isBlinking = true;

        for (int i = 0; i < blinkCount; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(blinkDuration);
            sr.enabled = true;
            yield return new WaitForSeconds(blinkDuration);
        }
        // Update is called once per frame
        isBlinking = false;
    }
}
