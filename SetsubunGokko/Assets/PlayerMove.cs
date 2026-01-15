using Unity.Hierarchy;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float baseSpeed = 5f;

    [Header("Screen Limits")]
    public float minX = -7f, maxX = 7f, minY = -4f, maxY = 4f;

    float speedMultiplier = 1f;
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        float speed = baseSpeed * speedMultiplier;

        Vector3 pos = transform.position;
        pos.x += moveX * speed * Time.deltaTime;
        pos.y += moveY * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = Mathf.Max(0f, multiplier);
    }

    public float GetSpeedMultiplier() => speedMultiplier;
}
