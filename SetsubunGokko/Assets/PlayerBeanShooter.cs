using UnityEngine;
public class PlayerBeanShooter : MonoBehaviour
{
    [Header("Ammo")]
    public int beans = 3;
    public int maxBeans = 3;
    [Header("Bean Prefab (Projectile)")]
    public GameObject beanPrefab;
    [Header("Shoot Settings")]
    public float shootCooldown = 0.2f;
    float lastDirX = 1f; // default shoots right
    float lastDirY = 0f;
    float cooldownTimer = 0f;
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        // Track last movement direction (4-dir)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveX != 0 || moveY != 0)
        {
            if (Mathf.Abs(moveX) >= Mathf.Abs(moveY))
            {
                lastDirX = Mathf.Sign(moveX);
                lastDirY = 0f;
            }
            else
            {
                lastDirX = 0f;
                lastDirY = Mathf.Sign(moveY);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
            TryShoot();
    }
    void TryShoot()
    {
        if (beans <= 0) return;
        if (cooldownTimer > 0f) return;
        if (beanPrefab == null) return;
        beans--;
        cooldownTimer = shootCooldown;
        Vector3 spawnPos = transform.position + new Vector3(lastDirX, lastDirY, 0f) * 0.6f;
        GameObject bean = Instantiate(beanPrefab, spawnPos, Quaternion.identity);
        var proj = bean.GetComponent<BeanProjectile>();
        if (proj != null)
            proj.SetDirection(new Vector2(lastDirX, lastDirY));
        Debug.Log($"Beans left: {beans}/{maxBeans}");
    }
    // Called by pickup
    public bool TryAddBeans(int amount)
    {
        int before = beans;
        beans = Mathf.Clamp(beans + amount, 0, maxBeans);
        bool changed = beans != before;
        if (changed)
            Debug.Log($"Picked up beans: {beans}/{maxBeans}");
        return changed; // tells spawner/pickup whether it actually added
    }
}