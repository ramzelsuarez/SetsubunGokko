using System.Collections;
using UnityEngine;
public class BeanPickupSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject beanPickupPrefab;
    [Header("Timing")]
    public float startDelay = 5f;      // wait 5 seconds after game starts
    public float lifeTime = 7f;        // how long a bean stays if not picked
    public float spawnInterval = 0f;   // delay before next spawn after despawn
    [Header("Spawn Area (match your camera bounds)")]
    public float minX = -7f, maxX = 7f, minY = -4f, maxY = 4f;
    GameObject currentPickup;
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }
    IEnumerator SpawnLoop()
    {
        // Initial delay before any beans appear
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            // Spawn bean
            Vector3 pos = new Vector3(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY),
                0f
            );
            currentPickup = Instantiate(beanPickupPrefab, pos, Quaternion.identity);
            // Wait until picked up or lifetime expires
            float timer = 0f;
            while (timer < lifeTime)
            {
                if (currentPickup == null) break; // picked up
                timer += Time.deltaTime;
                yield return null;
            }
            // Despawn if still exists
            if (currentPickup != null)
            {
                Destroy(currentPickup);
                currentPickup = null;
            }
            // Wait before spawning next bean
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}